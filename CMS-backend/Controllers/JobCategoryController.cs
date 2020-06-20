using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS;
using CMSBackend.Models.Entity.JobCategory;
using Common.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private JobCategoryBus _JobCategoryBUS = JobCategoryBus.GetJobCategoryBUSInstance();

        // GET: api/JobCategory
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/JobCategory/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetJobCategoryById(int id)
        {
            return Ok(_JobCategoryBUS.GetJobCategoryId(id));
        }

        // POST: api/JobCategory


        // PUT: api/JobCategory/5
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
        public IActionResult GetAllJobCategory ([FromBody] BaseCondition<JobCategory> condition)
        {
            return Ok(_JobCategoryBUS.GetAll(condition));
        }
        [HttpPost]
        public IActionResult AddNewJobCategory([FromBody] JobCategory jobCategory)
        {
            return Ok(_JobCategoryBUS.AddNewJobCategory(jobCategory));
        }
        [HttpPost]
        public IActionResult UpdateJobCategory(JobCategory jobCategory)
        {
            return Ok(_JobCategoryBUS.UpdateJobCategory(jobCategory));
        }
        [HttpPost]
        public IActionResult DeleteJobCategory([FromQuery] int id)
        {
            return Ok(_JobCategoryBUS.DeleteJobCategory(id));
        }

    }
}
