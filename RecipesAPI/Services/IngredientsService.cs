using AutoMapper;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using RecipesAPI.Resources.Ingredients;
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

        public Task<IngredientResource> AddAsync(IngredientInputResource resource)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IngredientResource>> ListAsync()
        {
            var categories = await this.ingredientsRepository.ListAsync();

            return this.mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientResource>>(categories);
        }
    }
}
