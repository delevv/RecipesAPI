using RecipesAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();

        Task AddAsync(Category category);

        Task<Category> GetByIdAsync(int id);

        Task UpdateAsync(Category category);

        Task RemoveAsync(Category category);
    }
}
