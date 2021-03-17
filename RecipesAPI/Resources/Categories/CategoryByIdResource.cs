using RecipesAPI.Resources.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Resources.Categories
{
    public class CategoryByIdResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<RecipeInCategoryResource> Recipes { get; set; }
    }
}
