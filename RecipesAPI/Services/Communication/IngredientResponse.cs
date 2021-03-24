using RecipesAPI.Resources.Ingredients;

namespace RecipesAPI.Services.Communication
{
    public class IngredientResponse : BaseResponse
    {
        public IngredientResource Ingredient { get; }

        private IngredientResponse(bool success, string message, IngredientResource category)
            : base(success, message)
        {
            this.Ingredient = category;
        }

        public IngredientResponse(IngredientResource ingredient)
         : this(true, string.Empty, ingredient)
        {
        }

        // error response
        public IngredientResponse(string message)
            : this(false, message, null)
        {
        }
    }
}
