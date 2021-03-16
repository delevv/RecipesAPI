using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task AddAsync(Category category)
        {
            await this.context.Categories.AddAsync(category);
            await this.context.SaveChangesAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await this.context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await this.context.Categories.ToListAsync();
        }

        public async Task RemoveAsync(Category category)
        {
            this.context.Categories.Remove(category);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            this.context.Categories.Update(category);
            await this.context.SaveChangesAsync();
        }
    }
}
