using RecipesAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Resources.Ingredients
{
    public class IngredientInputResource
    {
        [Required]
        [MaxLength(GlobalConstants.IngredientNameMaxLength)]
        public string Name { get; set; }
    }
}
