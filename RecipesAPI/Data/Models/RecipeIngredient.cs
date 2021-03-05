using RecipesAPI.Common;
using RecipesAPI.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        [Range(GlobalConstants.MinQuantity, GlobalConstants.MaxQuantity)]
        public double Quantity { get; set; }

        public UnitOfMeasurement? IngredientMeasurement { get; set; }
    }
}
