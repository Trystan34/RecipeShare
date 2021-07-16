using api.GraphQL;
using api.GraphQL.Mutation;
using api.GraphQL.Query;
using api.GraphQL.Subscription;
using api.GraphQL.Types;
using api.Helpers;
using api.Interfaces;
using api.Repositories;
using api.Services;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Execution;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<AppDbContext>(options =>
                {
                    options.UseNpgsql(Configuration["ConnectionString"]);
                })
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IFieldService, FieldService>()
                .AddSingleton<IDocumentExecuter, SubscriptionDocumentExecuter>()

                .AddScoped<IRecipeHelper, RecipeHelper>()

                .AddScoped<MainQuery>()
                .AddScoped<MainMutation>()
                .AddSingleton<ISubscriptionServices, SubscriptionServices>()
                .AddScoped<MainSubscription>()

                .AddScoped<RecipeType>()
                .AddScoped<RecipeCategoryType>()
                .AddScoped<GraphQLSchema>()
                .AddCors()
                .AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = Environment.IsDevelopment();
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                })
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = Environment.IsDevelopment())
                .AddDataLoader()
                .AddWebSockets()
                .AddGraphTypes(typeof(GraphQLSchema));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger<Startup>();
            logger.LogInformation($"ConnectionString: {Configuration["ConnectionString"]}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
                }
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseWebSockets();
            app.UseGraphQLWebSockets<GraphQLSchema>();
            app.UseGraphQL<GraphQLSchema>();
            app.UseGraphQLAltair();
        }
    }
}
