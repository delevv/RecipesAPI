using RecipesAPI.Data.Models;

namespace RecipesAPI.Services.Communication
{
    public class AddCategoryResponse : BaseResponse
    {
        public Category Category { get; }

        private AddCategoryResponse(bool success, string message, Category category)
            : base(success, message)
        {
            this.Category = category;
        }

        // success response
        public AddCategoryResponse(Category category)
            : this(true, string.Empty, category)
        {
        }

        // error response
        public AddCategoryResponse(string message)
            : this(false, message, null)
        {
        }
    }
}
