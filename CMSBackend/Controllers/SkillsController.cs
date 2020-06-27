using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS;
using CMSBackend.Models.Entity.Skills;
using Common.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private SkillsBus _skillsBus = SkillsBus.GetSkillsBUSInstance();
        // GET: api/Skills
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Skills/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSkillsById(int id)
        {
            return Ok(_skillsBus.GetSkillsById(id));
        }


        // POST: api/Skills
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Skills/5
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
        public IActionResult GetAllSkillsWithSearchPaging([FromBody] BaseCondition<Skills> condition)
        {
            return Ok(_skillsBus.GetAllWithSearchPaging(condition));
        }

        [HttpPost]
        public IActionResult AddNewSkills([FromBody] Skills Skills)
        {
            return Ok(_skillsBus.AddNewSkills(Skills));
        }

        [HttpPost]
        public IActionResult UpdateSkills(Skills Skills)
        {
            return Ok(_skillsBus.UpdateSkills(Skills));
        }

        [HttpPost]
        public IActionResult DeleteSkills([FromQuery] int id)
        {
            return Ok(_skillsBus.DeleteSkills(id));
        }
    }
}
