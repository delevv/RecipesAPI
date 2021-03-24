using AutoMapper;
using RecipesAPI.Common;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using RecipesAPI.Resources.Ingredients;
using RecipesAPI.Services.Communication;
using RecipesAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientsRepository ingredientsRepository;
        private readonly IMapper mapper;

        public IngredientsService(IIngredientsRepository ingredientsRepository, IMapper mapper)
        {
            this.ingredientsRepository = ingredientsRepository;
            this.mapper = mapper;
        }

        public async Task<IngredientResponse> AddAsync(IngredientInputResource resource)
        {
            try
            {
                var ingredient = this.mapper.Map<IngredientInputResource, Ingredient>(resource);

                await this.ingredientsRepository.AddAsync(ingredient);

                var ingredientResource = this.mapper.Map<Ingredient, IngredientResource>(ingredient);

                return new IngredientResponse(ingredientResource);
            }
            catch (Exception ex)
            {
                //TODO: Log errors

                return new IngredientResponse(string.Format(GlobalConstants.AddIngredientErrorMessage, ex.Message));
            }
        }

        public async Task<IEnumerable<IngredientResource>> ListAsync()
        {
            var categories = await this.ingredientsRepository.ListAsync();

            return this.mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientResource>>(categories);
        }
    }
}
