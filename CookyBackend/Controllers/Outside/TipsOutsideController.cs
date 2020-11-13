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
    public class TipsOutsideController : Controller
    {
        private TipsOutsideBUS _TipsOutsideBUS = TipsOutsideBUS.GetTipsOutsideBUSInstance();
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
        public IActionResult AddNewTips([FromBody] Tip tip)
        {
            return Ok(_TipsOutsideBUS.AddNewTip(tip));
        }

    }
}