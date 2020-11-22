using CMSBackend.Common;
using Common.Common;
using CookyBackend.DAL.OusideDAL;
using CookyBackend.Models.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.BUS.Outside
{
    public class UserOutsideBus
    {
        private UserDAL _UserDAL = UserDAL.UserDALInstance();
        private UserOutsideBus()
        {

        }
        private static UserOutsideBus _instance;
        public static UserOutsideBus GetUserOutsideBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new UserOutsideBus();
            }
            return _instance;
        }

        public ReturnResult<User> GetUsersWithPaging(BaseCondition<User> condition)
        {
            return _UserDAL.GetUsersWithPaging(condition);
        }

        public ReturnResult<User> Login(string username, string password)
        {
            return _UserDAL.Login(username,password);
        }
        public ReturnResult<User> Register(User User)
        {
            return _UserDAL.Register(User);
        }
        public ReturnResult<User> GetUserById(int id)
        {
            return _UserDAL.GetUserById(id);
        }
        public ReturnResult<User> ActiveUser(User user)
        {
            return _UserDAL.ActiveUser(user);
        }
        //public ReturnResult<User> UpdateUser(User User)
        //{
        //    return _UserDAL.UpdateUser(User);
        //}
        //public ReturnResult<User> DeleteRecipe(int id)
        //{
        //    return _UserDAL.DeleteUser(id);
        //}
    }
}
