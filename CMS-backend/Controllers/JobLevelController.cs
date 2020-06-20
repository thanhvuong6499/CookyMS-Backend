using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobLevelController : ControllerBase
    {
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
    }
}
