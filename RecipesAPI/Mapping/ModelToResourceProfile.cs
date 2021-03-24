using AutoMapper;
using RecipesAPI.Data.Models;
using RecipesAPI.Extensions;
using RecipesAPI.Resources.Categories;
using RecipesAPI.Resources.Ingredients;
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

            // Recipe
            CreateMap<Recipe, RecipeResource>()
                .ForMember(r => r.CookingTime,
                opt => opt.MapFrom(x => x.CookingTime.TotalMinutes));

            CreateMap<Recipe, RecipeInCategoryResource>();

            CreateMap<Recipe, RecipeByIdResource>()
                .ForMember(r => r.CookingTime,
                opt => opt.MapFrom(x => x.CookingTime.TotalMinutes));

            // Ingredients
            CreateMap<RecipeIngredient, IngredientInRecipeResource>()
                .ForMember(i => i.IngredientMeasurement,
                    opt => opt.MapFrom(x => x.IngredientMeasurement.ToDescriptionString()))
                .ForMember(i => i.Id,
                    opt => opt.MapFrom(x => x.IngredientId))
                .ForMember(i => i.Name,
                    opt => opt.MapFrom(x => x.Ingredient.Name));

            CreateMap<Ingredient, IngredientResource>();
        }
    }
}
