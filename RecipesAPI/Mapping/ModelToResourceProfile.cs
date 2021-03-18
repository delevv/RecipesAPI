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
            // Category
            CreateMap<Category, CategoryResource>();

            CreateMap<Category, CategoryByIdResource>();

            CreateMap<Recipe, RecipeInCategoryResource>();


            // Recipe
            CreateMap<Recipe, RecipeResource>()
                .ForMember(r => r.CookingTime,
                opt => opt.MapFrom(x => x.CookingTime.TotalMinutes));
        }
    }
}
