using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Data.Models.Enums
{
    public enum UnitOfMeasurement
    {
        [Description("tsp")]
        teaspoon = 1,

        [Description("tbsp")]
        tablespoon = 2,
        
        [Description("cup")]
        cup = 3,

        [Description("ml")]
        milliliter = 4,

        [Description("l")]
        liter = 5,

        [Description("mg")]
        milligram = 6,

        [Description("g")]
        gram = 7,

        [Description("kg")]
        kilogram = 8,

        [Description("un")]
        unity = 9,
    }
}
