using RecipesAPI.Data.Models;
using RecipesAPI.Resources.Categories;
using RecipesAPI.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResource>> ListAsync();

        Task<CategoryByIdResource> GetByIdAsync(int id);

        Task<CategoryResponse> AddAsync(CategoryInputResource resource);

        Task<CategoryResponse> UpdateAsync(int id, CategoryInputResource category);

        Task<CategoryResponse> DeleteAsync(int id);
    }
}
