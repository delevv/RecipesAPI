using RecipesAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Resources.Ingredients
{
    public class IngredientInRecipeInputResource
    {
        [Required]
        [MaxLength(GlobalConstants.IngredientNameMaxLength)]
        public string Name { get; set; }

        [Range(GlobalConstants.MinQuantity, GlobalConstants.MaxQuantity)]
        public double Quantity { get; set; }

        [Required]
        public string IngredientMeasurement { get; set; }
    }
}
