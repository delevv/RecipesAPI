using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Data.Models;
using RecipesAPI.Extensions;
using RecipesAPI.Resources.Categories;
using RecipesAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await this.categoryService.ListAsync();

            return this.mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryInputResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = this.mapper.Map<CategoryInputResource, Category>(resource);
            var result = await this.categoryService.AddAsync(category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = this.mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryInputResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = this.mapper.Map<CategoryInputResource, Category>(resource);
            var result = await this.categoryService.UpdateAsync(id, category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = this.mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await this.categoryService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = this.mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);
        }
    }
}
