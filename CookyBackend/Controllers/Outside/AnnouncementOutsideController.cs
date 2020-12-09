using Common.Common;
using CookyBackend.BUS.Outside;
using CookyBackend.Models.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.Controllers.Outside
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnnouncementOutsideController : Controller
    {
        private AnnouncementBus _AnnouncementBus = AnnouncementBus.GetAnnouncementBusInstance();
        // GET: RecruitmentNews
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        public IActionResult GetAllAnnouncementWithPaging([FromBody] BaseCondition<Announcement> condition)
        {
            return Ok(_AnnouncementBus.GetAllAnnouncementPaging(condition));
        }

        [HttpPost]
        public IActionResult AddNewAnnouncement([FromBody] Announcement Announcement)
        {
            return Ok(_AnnouncementBus.InsertAnnouncement(Announcement));
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement Announcement)
        {
            return Ok(_AnnouncementBus.UpdateAnnouncement(Announcement));
        }
        [HttpPost]
        public IActionResult DeleteAnnouncement([FromQuery] int id)
        {
            return Ok(_AnnouncementBus.DeleteAnnouncement(id));
        }
    }
}
