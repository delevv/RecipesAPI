using AutoMapper;
using RecipesAPI.Common;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Models.Enums;
using RecipesAPI.Data.Repositories.Interfaces;
using RecipesAPI.Resources.Recipes;
using RecipesAPI.Services.Communication;
using RecipesAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesRepository recipeRepository;
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IIngredientsRepository ingredientsRepository;
        private readonly IMapper mapper;

        public RecipesService(
            IRecipesRepository recipeRepository,
            ICategoriesRepository categoriesRepository,
            IIngredientsRepository ingredientsRepository,
            IMapper mapper)
        {
            this.recipeRepository = recipeRepository;
            this.categoriesRepository = categoriesRepository;
            this.ingredientsRepository = ingredientsRepository;
            this.mapper = mapper;
        }

        public async Task<RecipeResponse> AddAsync(RecipeInputResource resource)
        {
            var currentRecipe = new Recipe
            {
                ImageUrl = resource.ImageUrl,
                Name = resource.Name,
                Instructions = resource.Instructions,
                CookingTime = TimeSpan.FromMinutes(resource.CookingTime)
            };

            var category = await this.categoriesRepository.GetByNameAsync(resource.Category);

            if (category == null)
            {
                category = new Category()
                {
                    Name = resource.Category,
                };
            }

            currentRecipe.Category = category;

            foreach (var recipeIngredient in resource.Ingredients)
            {
                var currentIngredient = await this.ingredientsRepository.GetByNameAsync(recipeIngredient.Name);

                if (currentIngredient == null)
                {
                    currentIngredient = new Ingredient()
                    {
                        Name = recipeIngredient.Name,
                    };
                }

                UnitOfMeasurement measurment;

                var isEnumParsed = Enum.TryParse(recipeIngredient.IngredientMeasurement, true, out measurment);

                if (!isEnumParsed)
                {
                    return new RecipeResponse(string.Format(GlobalConstants.WrongRecipeIngredientMeasurmentMessage, recipeIngredient.Name));
                }

                var currentRecipeIngredient = new RecipeIngredient()
                {
                    Ingredient = currentIngredient,
                    Recipe = currentRecipe,
                    Quantity = recipeIngredient.Quantity,
                    IngredientMeasurement = measurment,
                };

                currentRecipe.RecipeIngredients.Add(currentRecipeIngredient);
            }

            try
            {
                await this.recipeRepository.AddAsync(currentRecipe);

                var recipeResourse = this.mapper.Map<Recipe, RecipeByIdResource>(currentRecipe);

                return new RecipeResponse(recipeResourse);
            }
            catch (Exception ex)
            {
                return new RecipeResponse(string.Format(GlobalConstants.AddRecipeErrorMessage, ex.Message));
            }
        }

        public async Task<IEnumerable<RecipeResource>> ListAsync()
        {
            var recipes = await this.recipeRepository.ListAsync();

            return this.mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeResource>>(recipes);
        }
    }
}
