using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
            //var file = Request.Form.Files[0];
            //var folderName = Path.Combine("Resources", "Images");
            //if (!Directory.Exists(folderName))
            //{
            //    Directory.CreateDirectory(folderName);
            //}
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //if (file.Length > 0)
            //{
            //    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //    var fullPath = Path.Combine(pathToSave, fileName);
            //    var dbPath = Path.Combine(folderName, fileName);
            //    using (var stream = new FileStream(fullPath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }
            //    recipe.ImageBackgroundUrl = dbPath;
            //    //return Ok(new { dbPath });
            //    return Ok(_RecipeOutsideBUS.AddNewRecipe(recipe));

            //}
            //else
            //{
            //    return BadRequest();
            //}
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
        [HttpPost]
        public IActionResult AprroveRecipe([FromBody] int id)
        {
            return Ok(_RecipeOutsideBUS.ApproveRecipe(id));
        }
        [HttpPost]
        public IActionResult RejectRecipe([FromBody] int id)
        {
            return Ok(_RecipeOutsideBUS.RejectRecipe(id));
        }
        [HttpPost]
        public IActionResult GetAllRecipesPendingWithPaging([FromBody] BaseCondition<RecipeModel> condition)
        {
            return Ok(_RecipeOutsideBUS.GetAllRecipePending(condition));
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    dbPath = dbPath.Replace("\\", "/");
                    return Ok(new { dbPath });
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}