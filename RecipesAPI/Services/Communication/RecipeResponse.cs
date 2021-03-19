using RecipesAPI.Resources.Recipes;

namespace RecipesAPI.Services.Communication
{
    public class RecipeResponse : BaseResponse
    {
        public RecipeByIdResource Recipe { get; }

        public RecipeResponse(bool success, string message, RecipeByIdResource recipe) 
            : base(success, message)
        {
            Recipe = recipe;
        }


        // success response
        public RecipeResponse(RecipeByIdResource recipe)
            : this(true, string.Empty, recipe)
        {
        }

        // error response
        public RecipeResponse(string message)
            : this(false, message, null)
        {
        }
    }
}
