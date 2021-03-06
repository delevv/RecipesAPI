using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data.Models;

namespace RecipesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>()
                 .HasKey(ri => new { ri.RecipeId, ri.IngredientId });
        }
    }
}
