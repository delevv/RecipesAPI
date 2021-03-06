using RecipesAPI.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.IngredientNameMaxLength)]
        public string Name { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
