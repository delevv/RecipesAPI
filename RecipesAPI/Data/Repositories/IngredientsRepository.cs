using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Repositories
{
    public class IngredientsRepository : BaseRepository, IIngredientsRepository
    {
        public IngredientsRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Ingredient> GetByNameAsync(string name)
        {
            return await this.context.Ingredients.FirstOrDefaultAsync(i => i.Name.ToLower() == name.ToLower());
        }
    }
}
