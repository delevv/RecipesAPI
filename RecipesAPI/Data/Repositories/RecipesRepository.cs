using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Repositories
{
    public class RecipesRepository : BaseRepository, IRecipesRepository
    {
        public RecipesRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task AddAsync(Recipe recipe)
        {
            await this.context.Recipes.AddAsync(recipe);
            await this.context.SaveChangesAsync();
        }

        public async Task<Recipe> GetByIdAsync(int id)
        {
            return await this.context.Recipes
                .Include(r => r.Category)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(r => r.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Recipe>> ListAsync()
        {
            return await this.context.Recipes.Include(r => r.Category).ToListAsync();
        }
    }
}
