using RecipesAPI.Resources.Ingredients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Services.Interfaces
{
    public interface IIngredientsService
    {
        Task<IEnumerable<IngredientResource>> ListAsync();

        Task<IngredientResource> AddAsync(IngredientInputResource resource);
    }
}
