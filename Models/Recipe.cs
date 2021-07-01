using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeShare.Models
{
    /// <summary>
    /// The model definition
    /// </summary>
    public class Recipe
    {
        [Key]
        public Guid RecipeId { get; set; }
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
        public int CookTime { get; set; }
        public double Serves { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string VideoUrl { get; set; }
        public string VideoThumbnailUrl { get; set; }
        public string Notes { get; set; }
        public Guid CategoryId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CategoryId")]
        public RecipeCategory Category { get; set; }
    }
}
