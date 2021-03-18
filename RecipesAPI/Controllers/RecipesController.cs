using Microsoft.AspNetCore.Mvc;
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

    }
}
