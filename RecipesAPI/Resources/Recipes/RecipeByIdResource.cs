using RecipesAPI.Resources.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Resources.Recipes
{
    public class RecipeByIdResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public double CookingTime { get; set; }

        public string Instructions { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<IngredientInRecipeResource> RecipeIngredients { get; set; }
    }
}
