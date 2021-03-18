using AutoMapper;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using RecipesAPI.Resources.Recipes;
using RecipesAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IMapper mapper;

        public RecipesService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            this.recipeRepository = recipeRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RecipeResource>> ListAsync()
        {
            var recipes = await this.recipeRepository.ListAsync();

            return this.mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeResource>>(recipes);
        }
    }
}
