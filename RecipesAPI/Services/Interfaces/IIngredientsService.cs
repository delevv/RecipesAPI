using RecipesAPI.Resources.Ingredients;
using RecipesAPI.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Services.Interfaces
{
    public interface IIngredientsService
    {
        Task<IEnumerable<IngredientResource>> ListAsync();

        Task<IngredientResponse> AddAsync(IngredientInputResource resource);
    }
}
