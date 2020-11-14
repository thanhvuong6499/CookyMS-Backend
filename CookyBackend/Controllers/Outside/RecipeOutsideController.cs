using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS.Outside;
using Common.Common;
using CookyBackend.Models.Entity.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers.Outside
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipesOutsideController : Controller
    {
        private RecipeOutsideBUS _RecipeOutsideBUS = RecipeOutsideBUS.GetRecipeOutsideBUSInstance();
        // GET: RecruitmentNews
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: RecruitmentNews/Details/5
        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetRecruitmentNewsById(int id)
        //{
        //    return Ok(_RecipeOutsideBUS.GetRecruitmentNewsById(id));
        //}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
     
       
        [HttpPost]
        public IActionResult GetAllRecipesWithPaging([FromBody] BaseCondition<RecipeModel> condition)
        {
            return Ok(_RecipeOutsideBUS.GetAllRecipePaging(condition));
        }
        [HttpGet]
        public IActionResult GetListRecipe()
        {
            return Ok(_RecipeOutsideBUS.GetAllRecipes());
        }


        [HttpPost]
        public IActionResult AddNewRecipe([FromBody] RecipeModel recipe)
        {
            return Ok(_RecipeOutsideBUS.AddNewRecipe(recipe));
        }

    }
}