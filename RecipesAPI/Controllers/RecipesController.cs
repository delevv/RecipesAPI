using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Extensions;
using RecipesAPI.Resources.Recipes;
using RecipesAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Controllers
{
    [Route("[controller]")]
    public class RecipesController : Controller
    {
        private readonly IRecipesService recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        [HttpGet]
        public async Task<IEnumerable<RecipeResource>> GetAllAsync()
        {
            return await this.recipesService.ListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RecipeInputResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await this.recipesService.AddAsync(resource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Recipe);
        }
    }
}
