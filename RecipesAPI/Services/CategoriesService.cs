using AutoMapper;
using RecipesAPI.Common;
using RecipesAPI.Data.Models;
using RecipesAPI.Data.Repositories.Interfaces;
using RecipesAPI.Resources.Categories;
using RecipesAPI.Services.Communication;
using RecipesAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoriesService(ICategoriesRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryResponse> AddAsync(CategoryInputResource resource)
        {
            try
            {
                var category = this.mapper.Map<CategoryInputResource, Category>(resource);

                await this.categoryRepository.AddAsync(category);

                var categoryResource = this.mapper.Map<Category, CategoryResource>(category);

                return new CategoryResponse(categoryResource);
            }
            catch (Exception ex)
            {
                //TODO: Log errors

                return new CategoryResponse(string.Format(GlobalConstants.AddCategoryErrorMessage, ex.Message));
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var category = await this.categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                return new CategoryResponse(GlobalConstants.CategoryNotFoundMessage);
            }

            try
            {
                await this.categoryRepository.RemoveAsync(category);

                var categoryResource = this.mapper.Map<Category, CategoryResource>(category);

                return new CategoryResponse(categoryResource);
            }
            catch (Exception ex)
            {
                //TODO: Log errors

                return new CategoryResponse(string.Format(GlobalConstants.DeleteCategoryErrorMessage, ex.Message));
            }
        }

        public async Task<CategoryByIdResource> GetByIdAsync(int id)
        {
            var category = await this.categoryRepository.GetByIdAsync(id);

            return this.mapper.Map<Category, CategoryByIdResource>(category);
        }

        public async Task<IEnumerable<CategoryResource>> ListAsync()
        {
            var categories = await this.categoryRepository.ListAsync();

            return this.mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
        }

        public async Task<CategoryResponse> UpdateAsync(int id, CategoryInputResource resource)
        {
            var currCategory = await this.categoryRepository.GetByIdAsync(id);

            if (currCategory == null)
            {
                return new CategoryResponse(GlobalConstants.CategoryNotFoundMessage);
            }

            currCategory.Name = resource.Name;

            try
            {
                await this.categoryRepository.UpdateAsync(currCategory);

                var categoryResource = this.mapper.Map<Category, CategoryResource>(currCategory);

                return new CategoryResponse(categoryResource);
            }
            catch (Exception ex)
            {
                //TODO: Log errors

                return new CategoryResponse(string.Format(GlobalConstants.UpdateCategoryErrorMessage, ex.Message));
            }
        }
    }
}
