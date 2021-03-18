using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Repositories
{
    public class RecipeRepository : BaseRepository, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Recipe>> ListAsync()
        {
            return await this.context.Recipes.ToListAsync();
        }
    }
}
