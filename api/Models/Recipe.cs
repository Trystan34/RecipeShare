using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("recipe", Schema = "business")]
    public partial class Recipe : BaseEntity
    {
        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        [StringLength(150)]
        public string ShortDescription { get; set; }
        [StringLength(1500)]
        public string LongDescription { get; set; }
        public string AllergyInformation { get; set; }
        public double Rating { get; set; }
        public int PreparationTime { get; set; }
        // [GraphQLDescription("The time it takes to cook the recipe.")]
        public int CookTime { get; set; }
        public double Serves { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string VideoUrl { get; set; }
        public string VideoThumbnailUrl { get; set; }
        public string Notes { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public RecipeCategory Category { get; set; }
    }
}
