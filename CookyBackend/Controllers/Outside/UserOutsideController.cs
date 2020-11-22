using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Common;
using CookyBackend.BUS.Outside;
using CookyBackend.Models.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CookyBackend.Controllers.Outside
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserOutsideController : Controller
    {
        private UserOutsideBus _UserOutsideBus = UserOutsideBus.GetUserOutsideBUSInstance();
        // GET: RecruitmentNews
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: RecruitmentNews/Details/5
        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetRecruitmentNewsById(int id)
        //{
        //    return Ok(_UserOutsideBus.GetRecruitmentNewsById(id));
        //}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpPost]
        public IActionResult GetAllUserWithPaging([FromBody] BaseCondition<User> condition)
        {
            return Ok(_UserOutsideBus.GetUsersWithPaging(condition));
        }

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            return Ok(_UserOutsideBus.Login(user.Username,user.Password));
        }
        [HttpPost]
        public IActionResult Register([FromBody] User User)
        {
            return Ok(_UserOutsideBus.Register(User));
        }
        [HttpPost]
        public IActionResult GetUserById([FromBody] int id)
        {
            return Ok(_UserOutsideBus.GetUserById(id));
        }
        [HttpPost]
        public IActionResult ActiveUser(User User)
        {
            return Ok(_UserOutsideBus.ActiveUser(User));
        }
        //[HttpPost]
        //public IActionResult DeleteUser([FromQuery] int id)
        //{
        //    return Ok(_UserOutsideBus.DeleteUser(id));
        //}

    }
}
