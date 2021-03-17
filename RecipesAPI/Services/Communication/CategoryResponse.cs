using RecipesAPI.Data.Models;
using RecipesAPI.Resources.Categories;

namespace RecipesAPI.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public CategoryResource Category { get; }

        private CategoryResponse(bool success, string message, CategoryResource category)
            : base(success, message)
        {
            this.Category = category;
        }

        // success response
        public CategoryResponse(CategoryResource category)
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
