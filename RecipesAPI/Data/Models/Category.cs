using RecipesAPI.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CategoryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
