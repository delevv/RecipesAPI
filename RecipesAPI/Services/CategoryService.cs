using RecipesAPI.Common;
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

        public async Task<CategoryResponse> AddAsync(Category category)
        {
            try
            {
                await this.categoryRepository.AddAsync(category);

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                //TODO: Log errors

                return new CategoryResponse(string.Format(GlobalConstants.AddCategoryErrorMessage, ex.Message));
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var currCategory = await this.categoryRepository.GetByIdAsync(id);

            if (currCategory == null)
            {
                return new CategoryResponse(GlobalConstants.CategoryNotFoundMessage);
            }

            try
            {
                await this.categoryRepository.RemoveAsync(currCategory);

                return new CategoryResponse(currCategory);
            }
            catch (Exception ex)
            {
                //TODO: Log errors

                return new CategoryResponse(string.Format(GlobalConstants.DeleteCategoryErrorMessage, ex.Message));
            }
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await this.categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var currCategory = await this.categoryRepository.GetByIdAsync(id);

            if (currCategory == null)
            {
                return new CategoryResponse(GlobalConstants.CategoryNotFoundMessage);
            }

            currCategory.Name = category.Name;

            try
            {
                await this.categoryRepository.UpdateAsync(currCategory);

                return new CategoryResponse(currCategory);
            }
            catch (Exception ex)
            {
                //TODO: Log errors

                return new CategoryResponse(string.Format(GlobalConstants.UpdateCategoryErrorMessage, ex.Message));
            }
        }
    }
}
