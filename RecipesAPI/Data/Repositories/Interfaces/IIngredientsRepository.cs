using RecipesAPI.Data.Models;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Repositories.Interfaces
{
    public interface IIngredientsRepository
    {
        Task<Ingredient> GetByNameAsync(string name);
    }
}
