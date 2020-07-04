using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS;
using CMSBackend.Models.Entity.JobPositon;
using CMSBackend.Models.Entity.Branch;
using Common.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private BranchBUS _BranchBUS = BranchBUS.GetBranchBUSInstance();
        // GET: api/Branch
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Branch/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBranchById(int id)
        {
            return Ok(_BranchBUS.GetBranchId(id));
        }

        // POST: api/Branch
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Branch/5
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
        public IActionResult GetAllBranchWithSearchPaging([FromBody] BaseCondition<Branch> condition)
        {
            return Ok(_BranchBUS.GetAllWithSearchPaging(condition));
        }

        [HttpPost]
        public IActionResult AddNewBranch([FromBody] Branch Branch)
        {
            return Ok(_BranchBUS.AddNewBranch(Branch));
        }

        [HttpPost]
        public IActionResult DeleteBranch([FromQuery] int id)
        {
            return Ok(_BranchBUS.DeleteBranch(id));
        }
    }
}
