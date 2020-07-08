using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS;
using CMSBackend.Models.Entity.ViewModel;
using Common.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InsideRecruitmentNewsController : ControllerBase
    {
        private InsideRecruitmentNewsBUS _InsideRecruitmentNewsBUS = InsideRecruitmentNewsBUS.GetInsideRecruitmentNewsBUSInstance();
        // GET: api/InsideRecruitmentNews
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/InsideRecruitmentNews/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRecruitmentNewsById(int id)
        {
            return Ok(_InsideRecruitmentNewsBUS.GetRecruitmentNewsId(id));
        }

        // POST: api/InsideRecruitmentNews
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/InsideRecruitmentNews/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost]
        public IActionResult InsertRecruitmentNews([FromBody] RecruitmentNewsModel recruitmentNews)
        {
            return Ok(_InsideRecruitmentNewsBUS.AddNewRecruitmentNews(recruitmentNews));
        }
        [HttpPost]
        public IActionResult GetAllRecruitmentNewsWithPaging([FromBody] BaseCondition<RecruitmentNewsModel> condition)
        {
            return Ok(_InsideRecruitmentNewsBUS.GetAllRecruitmentNewsPaging(condition));
        }
        [HttpPost]
        public IActionResult UpdateRecruitmentNews(RecruitmentNewsModel recruitmentNews)
        {
            return Ok(_InsideRecruitmentNewsBUS.UpdateRecruitmentNews(recruitmentNews));
        }
    }
}
