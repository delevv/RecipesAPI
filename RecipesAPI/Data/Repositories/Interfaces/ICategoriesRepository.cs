using RecipesAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> ListAsync();

        Task AddAsync(Category category);

        Task<Category> GetByIdAsync(int id);

        Task<Category> GetByNameAsync(string name);

        Task UpdateAsync(Category category);

        Task RemoveAsync(Category category);
    }
}
