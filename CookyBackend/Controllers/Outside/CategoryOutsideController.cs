using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Common;
using CookyBackend.BUS.Outside;
using CookyBackend.Models.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CookyBackend.Controllers.Outside
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryOutsideController : Controller
    {
        private CategoryOutsideBus _CategoryOutsideBus = CategoryOutsideBus.GetCategoryOutsideBUSInstance();
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
        //    return Ok(_CategoryOutsideBus.GetRecruitmentNewsById(id));
        //}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        //[HttpPost]
        //public IActionResult GetAllCategoryWithPaging([FromBody] BaseCondition<Category> condition)
        //{
        //    return Ok(_CategoryOutsideBus.GetAllCategoryPaging(condition));
        //}

        //[HttpPost]
        //public IActionResult GetCategoryById([FromBody] int id)
        //{
        //    return Ok(_CategoryOutsideBus.GetCategoryId(id));
        //}
        [HttpPost]
        public IActionResult AddNewCategory([FromBody] Category Category)
        {
            return Ok(_CategoryOutsideBus.AddNewCategory(Category));
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category Category)
        {
            return Ok(_CategoryOutsideBus.UpdateCategory(Category));
        }
        [HttpPost]
        public IActionResult DeleteCategory([FromQuery] int id)
        {
            return Ok(_CategoryOutsideBus.DeleteCategory(id));
        }
        [HttpGet]
        public IActionResult GetAllNameCategory()
        {
            return Ok(_CategoryOutsideBus.GetAllNameCategory());
        }
        [HttpGet]
        public IActionResult GetAllIconCategory()
        {
            return Ok(_CategoryOutsideBus.GetAllIconCategory());
        }
    }
}
