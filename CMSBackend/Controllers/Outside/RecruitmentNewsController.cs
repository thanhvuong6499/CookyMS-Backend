using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS.Outside;
using CMSBackend.Models.Entity.ViewModel;
using Common.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers.Outside
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecruitmentNewsController : Controller
    {
        private RecruitmentNewsBUS _RecruitmentNewsBUS = RecruitmentNewsBUS.GetRecruitmentNewsBUSInstance();
        // GET: RecruitmentNews
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: RecruitmentNews/Details/5
        [HttpGet]
        [Route("{id}")]
        public void GetRecruitmentNewsById(int id)
        {
           
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
        public IActionResult GetAllRecruitmentNewsWithPaging([FromBody] BaseCondition<RecruitmentNewsModel> condition)
        {
            return Ok(_RecruitmentNewsBUS.GetAllRecruitmentNewsPaging(condition));
        }
    }
}