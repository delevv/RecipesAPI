using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RecipesAPI.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            var info = @enum.GetType().GetField(@enum.ToString());

            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes?[0].Description ?? @enum.ToString();
        }
    }
}
