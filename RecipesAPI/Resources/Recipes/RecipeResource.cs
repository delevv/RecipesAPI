using RecipesAPI.Resources.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Resources.Recipes
{
    public class RecipeResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public double CookingTime { get; set; }

        public CategoryResource Category { get; set; }
    }
}
