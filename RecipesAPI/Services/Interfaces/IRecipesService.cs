using RecipesAPI.Resources.Recipes;
using RecipesAPI.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Services.Interfaces
{
    public interface IRecipesService
    {
        Task<IEnumerable<RecipeResource>> ListAsync();

        Task<RecipeResponse> AddAsync(RecipeInputResource resource);
    }
}
