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
    public class JobPositionController : ControllerBase
    {
        // GET: api/JobPosition
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/JobPosition/5
        [HttpGet("{id}")]
        public string GetJobPositionById(int id)
        {
            return "value";
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
    }
}
