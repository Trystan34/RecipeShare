using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using api.Dto;

namespace api.Services
{
    public class RecipeAddedService
    {
        private readonly ISubject<RecipeAddedMessage> _messageStream = new ReplaySubject<RecipeAddedMessage>(1);
        public RecipeAddedMessage AddRecipeAddedMessage(RecipeAddedMessage message)
        {
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<RecipeAddedMessage> GetMessages(string CategoryName)
        {
            var mess = _messageStream
                .Where(message =>
                    message.CategoryName == CategoryName
                ).Select(s => s)
                .AsObservable();

            return mess;
        }
    }
}
