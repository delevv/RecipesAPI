using RecipesAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Resources.Categories
{
    public class CategoryInputResource
    {

        [Required]
        [MaxLength(GlobalConstants.CategoryNameMaxLength)]
        public string Name { get; set; }
    }
}
