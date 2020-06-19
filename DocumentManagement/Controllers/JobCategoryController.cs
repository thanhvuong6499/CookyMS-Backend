using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private JobCategoryBus _instanceBUS = JobCategoryBus.GetJobCategoryBUSInstance();

        // GET: api/JobCategory
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/JobCategory/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JobCategory
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

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

        [HttpGet]
        public IActionResult GetAllJobCategory ()
        {
            return Ok(_instanceBUS.GetAll());
        }
    }
}
