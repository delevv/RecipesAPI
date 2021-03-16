using RecipesAPI.Data.Models;
using RecipesAPI.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();

        Task<AddCategoryResponse> AddAsync(Category category);
    }
}
