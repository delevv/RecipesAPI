using AutoMapper;
using RecipesAPI.Data.Models;
using RecipesAPI.Resources.Categories;
using RecipesAPI.Resources.Recipes;

namespace RecipesAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Recipe, RecipeInCategoryResource>();
        }
    }
}
