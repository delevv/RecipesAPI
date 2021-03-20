using RecipesAPI.Common;
using RecipesAPI.Resources.Ingredients;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Resources.Recipes
{
    public class RecipeInputResource
    {
        [Required]
        [MaxLength(GlobalConstants.RecipeNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public double CookingTime { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Instructions { get; set; }

        public IEnumerable<IngredientInRecipeInputResource> Ingredients { get; set; }
    }
}
