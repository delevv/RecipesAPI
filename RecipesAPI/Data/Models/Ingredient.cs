using RecipesAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.IngredientNameMaxLength)]
        public string Name { get; set; }
    }
}
