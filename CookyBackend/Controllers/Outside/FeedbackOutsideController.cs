using Common.Common;
using CookyBackend.BUS.Outside;
using CookyBackend.Models.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.Controllers.Outside
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackOutsideController : Controller
    {
        private FeedbackBus _FeedbackBus = FeedbackBus.GetFeedbackBusInstance();
        // GET: RecruitmentNews
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        public IActionResult GetAllFeedbackWithPaging([FromBody] BaseCondition<Feedback> condition)
        {
            return Ok(_FeedbackBus.GetAllFeedbackPaging(condition));
        }

        [HttpPost]
        public IActionResult AddNewFeedback([FromBody] Feedback Feedback)
        {
            return Ok(_FeedbackBus.InsertFeedback(Feedback));
        }
    }
}
