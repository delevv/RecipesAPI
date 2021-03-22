namespace RecipesAPI.Resources.Ingredients
{
    public class IngredientInRecipeResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public string IngredientMeasurement { get; set; }
    }
}
