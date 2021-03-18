using RecipesAPI.Resources.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Services.Interfaces
{
    public interface IRecipesService
    {
        Task<IEnumerable<RecipeResource>> ListAsync();
    }
}
