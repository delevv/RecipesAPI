namespace RecipesAPI.Resources.Ingredients
{
    public class IngredientInRecipeResource
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public double Quantity { get; set; }

        public string IngredientMeasurement { get; set; }
    }
}
