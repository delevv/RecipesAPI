using AutoMapper;
using RecipesAPI.Data.Models;
using RecipesAPI.Resources.Categories;
using RecipesAPI.Resources.Ingredients;

namespace RecipesAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            // Category
            CreateMap<CategoryInputResource, Category>();

            // Ingredient
            CreateMap<IngredientInputResource, Ingredient>();
        }
    }
}
