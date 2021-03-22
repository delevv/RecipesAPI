namespace RecipesAPI.Common
{
    public static class GlobalConstants
    {
        //-------------Models Validation--------------

        // Ingredient
        public const int IngredientNameMaxLength = 30;

        // Recipe
        public const int RecipeNameMaxLength = 50;

        // Category
        public const int CategoryNameMaxLength = 50;

        // RecipeIngredient
        public const double MinQuantity = 0.01;
        public const double MaxQuantity = 999.99;

        //-------------Error Messages--------------

        // Category
        public const string CategoryNotFoundMessage = "Category not found.";
        public const string AddCategoryErrorMessage = "An error occurred when saving the category: {0}";
        public const string UpdateCategoryErrorMessage = "An error occurred when updating the category: {0}";
        public const string DeleteCategoryErrorMessage = "An error occurred when deleting the category: {0}";

        // Recipe
        public const string RecipeNotFoundMessage = "Recipe not found.";
        public const string WrongRecipeIngredientMeasurmentMessage = "Ingredient Measurment is wrong. Ingredient name - {0}";
        public const string AddRecipeErrorMessage = "An error occurred when saving the recipe: {0}";
    }
}
