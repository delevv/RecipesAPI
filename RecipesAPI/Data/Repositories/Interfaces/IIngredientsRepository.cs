using RecipesAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Repositories.Interfaces
{
    public interface IIngredientsRepository
    {
        Task<Ingredient> GetByNameAsync(string name);

        Task<IEnumerable<Ingredient>> ListAsync();

        Task AddAsync(Ingredient ingredient);
    }
}
