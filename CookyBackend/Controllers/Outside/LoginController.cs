using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSBackend.Common;
using CookyBackend.BUS.Outside;
using CookyBackend.Models.Entity.ViewModel;
using DocumentManagement.Models.Entity.Account;
using DocumentManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookyBackend.Controllers.Outside
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Đăng nhập tài khoản
        /// </summary>     
        [HttpPost]
        public IActionResult Login([FromBody] User account)
        {
            ReturnResult<User> loginResult;
            AccountService loginService = new AccountService();
            try
            {
                if (loginService.IsAuthenticate(account))
                {
                    // Create Jwt token for client-side
                    var jwtToken = loginService.CreateToken();
                    UserOutsideBus userBusiness = new UserOutsideBus();
                    var quser = userBusiness.Login(account.Username,account.Password);
                    var user = new User()
                    {

                        RegisterDate= quser.Item.RegisterDate,
                        ExpireDate = quser.Item.ExpireDate,
                        Id = quser.Item.Id,
                        Age = quser.Item.Age,
                        Email = quser.Item.Email,
                        Gender = quser.Item.Gender,
                        StatusPayment = quser.Item.StatusPayment,
                        isVip = quser.Item.isVip,
                        Username = account.Username,
                        Token = new Token()
                        {
                            JwtToken = jwtToken.JwtToken,
                            Expiration = jwtToken.Expiration
                        }
                    };
                    loginResult = new ReturnResult<User>()
                    {
                        Item = user,
                        ErrorCode = "0",
                        ErrorMessage = ""
                    };
                }
                else
                {
                    loginResult = new ReturnResult<User>()
                    {
                        IsSuccess = false,
                        ErrorCode = "-1",
                        ErrorMessage = "Tài khoản hoặc mật khẩu không chính xác, vui lòng thử lại.",
                    };
                }
            }
            catch (Exception ex)
            {
                loginResult = new ReturnResult<User>()
                {
                    IsSuccess = false,
                    ErrorCode = "1",
                    ErrorMessage = ex.Message
                };
            }
            return Ok(loginResult);
        }

    }
}