using RecipesAPI.Data.Models;
using RecipesAPI.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();

        Task<CategoryResponse> AddAsync(Category category);

        Task<CategoryResponse> UpdateAsync(int id, Category category);

        Task<CategoryResponse> DeleteAsync(int id);
    }
}
