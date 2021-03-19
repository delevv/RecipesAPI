using AutoMapper;
using RecipesAPI.Data.Models;
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
        private readonly IMapper mapper;

        public RecipesService(IRecipesRepository recipeRepository, ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            this.recipeRepository = recipeRepository;
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        public Task<RecipeResponse> AddAsync(RecipeInputResource resource)
        {
            var currentRecipe = new Recipe();
            
            currentRecipe.ImageUrl = resource.ImageUrl;
            currentRecipe.Name = resource.Name;
            currentRecipe.Instructions = resource.Instructions;
            currentRecipe.CookingTime = TimeSpan.FromMinutes(resource.CookingTime);

            var recipeCategory = this.categoriesRepository.GetByNameAsync(resource.Category);
        }

        public async Task<IEnumerable<RecipeResource>> ListAsync()
        {
            var recipes = await this.recipeRepository.ListAsync();

            return this.mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeResource>>(recipes);
        }
    }
}
