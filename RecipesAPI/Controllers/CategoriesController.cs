using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Common;
using RecipesAPI.Extensions;
using RecipesAPI.Resources.Categories;
using RecipesAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoryService;

        public CategoriesController(ICategoriesService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            return await this.categoryService.ListAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await this.categoryService.GetByIdAsync(id);

            if(category == null)
            {
                return NotFound(GlobalConstants.CategoryNotFoundMessage);
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryInputResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await this.categoryService.AddAsync(resource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Category);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryInputResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var result = await this.categoryService.UpdateAsync(id, resource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

           
            return Ok(result.Category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await this.categoryService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Category);
        }
    }
}
