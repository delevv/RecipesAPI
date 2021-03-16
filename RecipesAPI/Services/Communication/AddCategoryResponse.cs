using RecipesAPI.Data.Models;

namespace RecipesAPI.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; }

        private CategoryResponse(bool success, string message, Category category)
            : base(success, message)
        {
            this.Category = category;
        }

        // success response
        public CategoryResponse(Category category)
            : this(true, string.Empty, category)
        {
        }

        // error response
        public CategoryResponse(string message)
            : this(false, message, null)
        {
        }
    }
}
