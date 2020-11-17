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
    public class ContestOutsideController : Controller
    {
        private ContestOutsideBus _ContestOutsideBus = ContestOutsideBus.GetContestOutsideBUSInstance();
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
        //    return Ok(_ContestOutsideBus.GetRecruitmentNewsById(id));
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
        public IActionResult GetAllContestWithPaging([FromBody] BaseCondition<Contest> condition)
        {
            return Ok(_ContestOutsideBus.GetAllContestPaging(condition));
        }

        [HttpPost]
        public IActionResult GetContestById([FromBody] int id)
        {
            return Ok(_ContestOutsideBus.GetContestId(id));
        }
        [HttpPost]
        public IActionResult AddNewContest([FromBody] Contest contest)
        {
            return Ok(_ContestOutsideBus.AddNewContest(contest));
        }
        [HttpPost]
        public IActionResult UpdateContest(Contest contest)
        {
            return Ok(_ContestOutsideBus.UpdateContest(contest));
        }
        [HttpPost]
        public IActionResult DeleteContest([FromQuery] int id)
        {
            return Ok(_ContestOutsideBus.DeleteRecipe(id));
        }
    }
}
