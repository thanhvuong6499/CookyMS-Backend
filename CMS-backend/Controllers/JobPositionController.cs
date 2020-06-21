using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS;
using CMSBackend.Models.Entity.JobPositon;
using Common.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobPositionController : ControllerBase
    {
        private JobPositionBUS _jobLevelBUS = JobPositionBUS.GetJobPositionBUSInstance();
        // GET: api/JobPosition
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/JobPosition/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetJobPositionById(int id)
        {
            return Ok(_jobLevelBUS.GetJobPositionId(id));
        }

        // POST: api/JobPosition
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/JobPosition/5
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
        public IActionResult GetAllJobPositionWithSearchPaging([FromBody] BaseCondition<JobPosition> condition)
        {
            return Ok(_jobLevelBUS.GetAllWithSearchPaging(condition));
        }

        [HttpPost]
        public IActionResult AddNewJobPosition([FromBody] JobPosition JobPosition)
        {
            return Ok(_jobLevelBUS.AddNewJobPosition(JobPosition));
        }

        [HttpPost]
        public IActionResult UpdateJobPosition(JobPosition JobPosition)
        {
            return Ok(_jobLevelBUS.UpdateJobPosition(JobPosition));
        }

        [HttpPost]
        public IActionResult UpdateStatusJobPosition(JobPosition JobPosition)
        {
            return Ok(_jobLevelBUS.UpdateStatusJobPosition(JobPosition));
        }

        [HttpPost]
        public IActionResult DeleteJobPosition([FromQuery] int id)
        {
            return Ok(_jobLevelBUS.DeleteJobPosition(id));
        }
    }
}
