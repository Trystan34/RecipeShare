using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("recipe_category", Schema = "business")]
    public class RecipeCategory : BaseEntity
    {
        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    }
}
