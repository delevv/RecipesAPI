using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Extensions;
using RecipesAPI.Resources.Ingredients;
using RecipesAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesAPI.Controllers
{
    [Route("[controller]")]
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            this.ingredientsService = ingredientsService;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientResource>> GetAllAsync()
        {
            return await this.ingredientsService.ListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] IngredientInputResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await this.ingredientsService.AddAsync(resource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Ingredient);
        }
    }
}
