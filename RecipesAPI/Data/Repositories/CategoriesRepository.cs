using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Repositories
{
    public class CategoriesRepository : BaseRepository, ICategoriesRepository
    {
        public CategoriesRepository(ApplicationDbContext context)
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

        public async Task<Category> GetByNameAsync(string name)
        {
            return await this.context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
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
