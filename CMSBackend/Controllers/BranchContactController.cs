using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS;
using CMSBackend.Models.Entity.JobPositon;
using CMSBackend.Models.Entity.BranchContact;
using Common.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchContactController : ControllerBase
    {
        private BranchContactBUS _BranchContactBUS = BranchContactBUS.GetBranchContactBUSInstance();
        // GET: api/BranchContact
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BranchContact/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBranchContactById(int id)
        {
            return Ok(_BranchContactBUS.GetBranchContactId(id));
        }

        // POST: api/BranchContact
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/BranchContact/5
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
        public IActionResult GetAllBranchContactWithSearchPaging([FromBody] BaseCondition<BranchContact> condition)
        {
            return Ok(_BranchContactBUS.GetAllWithSearchPaging(condition));
        }

        [HttpPost]
        public IActionResult AddNewBranchContact([FromBody] BranchContact BranchContact)
        {
            return Ok(_BranchContactBUS.AddNewBranchContact(BranchContact));
        }

        [HttpPost]
        public IActionResult UpdateBranchContact(BranchContact BranchContact)
        {
            return Ok(_BranchContactBUS.UpdateBranchContact(BranchContact));
        }

        [HttpPost]
        public IActionResult DeleteBranchContact([FromQuery] int id)
        {
            return Ok(_BranchContactBUS.DeleteBranchContact(id));
        }
    }
}
