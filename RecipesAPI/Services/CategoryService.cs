using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using RecipesAPI.Services.Communication;
using RecipesAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<AddCategoryResponse> AddAsync(Category category)
        {
            try
            {
               await this.categoryRepository.AddAsync(category);

                return new AddCategoryResponse(category);
            }
            catch (Exception ex)
            {
                //TODO: Log errors

                return new AddCategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await this.categoryRepository.ListAsync();
        }
    }
}
