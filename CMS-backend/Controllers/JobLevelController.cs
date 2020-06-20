using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS;
using CMSBackend.Models.Entity.JobLevel;
using Common.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobLevelController : ControllerBase
    {
        private JobLevelBus _jobLevelBUS = JobLevelBus.GetJobLevelBUSInstance();
        // GET: api/JobLevel
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/JobLevel/5
        [HttpGet("{id}")]
        public string GetJobLevelById(int id)
        {
            return "value";
        }

        // POST: api/JobLevel
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/JobLevel/5
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
        public IActionResult GetAllJobLevelWithSearchPaging([FromBody] BaseCondition<JobLevel> condition)
        {
            return Ok(_jobLevelBUS.GetAllWithSearchPaging(condition));
        }

        [HttpPost]
        public IActionResult AddNewJobLevel([FromBody] JobLevel jobLevel)
        {
            return Ok(_jobLevelBUS.AddNewJobLevel(jobLevel));
        }

        [HttpPost]
        public IActionResult UpdateJobLevel(JobLevel jobLevel)
        {
            return Ok(_jobLevelBUS.UpdateJobLevel(jobLevel));
        }

        [HttpPost]
        public IActionResult DeleteJobLevel([FromQuery] int id)
        {
            return Ok(_jobLevelBUS.DeleteJobLevel(id));
        }
    }
}
