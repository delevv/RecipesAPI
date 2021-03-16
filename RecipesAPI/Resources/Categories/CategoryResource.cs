using RecipesAPI.Resources.Recipes;
using System.Collections.Generic;

namespace RecipesAPI.Resources.Categories
{
    public class CategoryResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<RecipeInCategoryResource> Recipes { get; set; }
    }
}
