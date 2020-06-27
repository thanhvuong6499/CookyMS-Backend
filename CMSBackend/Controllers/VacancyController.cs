using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.BUS;
using CMSBackend.Models.Entity.JobPositon;
using CMSBackend.Models.Entity.Vacancy;
using Common.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private VacancyBUS _vacancyBUS = VacancyBUS.GetVacancyBUSInstance();
        // GET: api/Vacancy
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Vacancy/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetVacancyById(int id)
        {
            return Ok(_vacancyBUS.GetVacancyId(id));
        }

        // POST: api/Vacancy
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Vacancy/5
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
        public IActionResult GetAllVacancyWithSearchPaging([FromBody] BaseCondition<Vacancy> condition)
        {
            return Ok(_vacancyBUS.GetAllWithSearchPaging(condition));
        }

        [HttpPost]
        public IActionResult AddNewVacancy([FromBody] Vacancy Vacancy)
        {
            return Ok(_vacancyBUS.AddNewVacancy(Vacancy));
        }

        [HttpPost]
        public IActionResult UpdateVacancy(Vacancy Vacancy)
        {
            return Ok(_vacancyBUS.UpdateVacancy(Vacancy));
        }

        [HttpPost]
        public IActionResult DeleteVacancy([FromQuery] int id)
        {
            return Ok(_vacancyBUS.DeleteVacancy(id));
        }
    }
}
