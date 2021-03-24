using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Resources.Ingredients;
using RecipesAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
