using RecipesAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Repositories.Interfaces
{
    public interface IRecipesRepository
    {
        Task<IEnumerable<Recipe>> ListAsync();

        Task AddAsync(Recipe recipe);
    }
}
