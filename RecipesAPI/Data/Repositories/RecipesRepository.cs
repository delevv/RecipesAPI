using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Recipe>> ListAsync()
        {
            return await this.context.Recipes.ToListAsync();
        }
    }
}
