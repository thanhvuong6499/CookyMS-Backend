﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS.Outside;
using Common.Common;
using CookyBackend.Common;
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
        [HttpPost]
        public IActionResult GetAllRecipesByUserIdWithPaging([FromBody] NewCondi condi)
        {
            return Ok(_RecipeOutsideBUS.GetAllRecipeByUserIdPaging(condi));
        }
        [HttpGet]
        public IActionResult GetListRecipe()
        {
            return Ok(_RecipeOutsideBUS.GetAllRecipes());
        }
        [HttpPost]
        public IActionResult GetRecipeSimilar([FromBody] int id)
        {
            return Ok(_RecipeOutsideBUS.GetAllRecipeSimilar(id));
        }



        [HttpPost]
        public IActionResult AddNewRecipe([FromBody] RecipeModel recipe)
        {
            return Ok(_RecipeOutsideBUS.AddNewRecipe(recipe));
        }
        [HttpPost]
        public IActionResult UpdateRecipce(RecipeModel recipe)
        {
            return Ok(_RecipeOutsideBUS.UpdateRecipe(recipe));
        }
        [HttpPost]
        public IActionResult DeleteRecipe([FromBody] int id)
        {
            return Ok(_RecipeOutsideBUS.DeleteRecipe(id));
        }
        [HttpPost]
        public IActionResult GetRecipeById([FromBody] int id)
        {
            return Ok(_RecipeOutsideBUS.GetRecipeById(id));
        }
    }
}