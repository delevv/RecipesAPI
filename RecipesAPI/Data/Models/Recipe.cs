using RecipesAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.RecipeNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public TimeSpan CookingTime { get; set; }

        [Required]
        public string Instructions { get; set; }
       
        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
