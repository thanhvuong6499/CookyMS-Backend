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
        public IActionResult GetTipById([FromBody] int id)
        {
            return Ok(_TipsOutsideBUS.GetTipId(id));
        }
        [HttpPost]
        public IActionResult GetAllTipWithPaging([FromBody] BaseCondition<Tip> condition)
        {
            return Ok(_TipsOutsideBUS.GetAllTipPaging(condition));
        }
        [HttpPost]
        public IActionResult GetAllTipPendingWithPaging([FromBody] BaseCondition<Tip> condition)
        {
            return Ok(_TipsOutsideBUS.GetAllTipPendingPaging(condition));
        }
        [HttpPost]
        public IActionResult AddNewTip([FromBody] Tip Tip)
        {
            return Ok(_TipsOutsideBUS.AddNewTip(Tip));
        }
        [HttpPost]
        public IActionResult UpdateTip(Tip Tip)
        {
            return Ok(_TipsOutsideBUS.UpdateTip(Tip));
        }
        [HttpPost]
        public IActionResult DeleteTip([FromBody] int id)
        {
            return Ok(_TipsOutsideBUS.DeleteTip(id));
        }
        [HttpPost]
        public IActionResult ApproveTip([FromBody] int id)
        {
            return Ok(_TipsOutsideBUS.ApproveTip(id));
        }
        [HttpPost]
        public IActionResult RejectTip([FromBody] int id)
        {
            return Ok(_TipsOutsideBUS.RejectTip(id));
        }
    }
}