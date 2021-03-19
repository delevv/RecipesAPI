using RecipesAPI.Resources.Ingredients;
using System.Collections.Generic;

namespace RecipesAPI.Resources.Recipes
{
    public class RecipeInputResource
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public double CookingTime { get; set; }

        public string Category { get; set; }

        public string Instructions { get; set; }

        public IEnumerable<IngredientInRecipeInputResource> Ingredients { get; set; }
    }
}
