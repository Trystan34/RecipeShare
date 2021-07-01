using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeShare.Models
{
    public class RecipeCategory
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        [StringLength(300)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
