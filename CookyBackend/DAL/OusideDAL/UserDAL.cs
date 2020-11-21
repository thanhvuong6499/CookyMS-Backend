using CMSBackend.Common;
using CMSBackend.DAL;
using Common.Common;
using CookyBackend.Models.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.DAL.OusideDAL
{
    public class UserDAL
    {
        private UserDAL()
        {

        }
        private static UserDAL _instance;
        public static UserDAL UserDALInstance()
        {
            if (_instance == null)
            {
                _instance = new UserDAL();
            }
            return _instance;
        }

        //public ReturnResult<User> GetUserPaging(BaseCondition<User> condition)
        //{
        //    DbProvider provider = new DbProvider();
        //    List<User> list = new List<User>();
        //    string outCode = String.Empty;
        //    string outMessage = String.Empty;
        //    string totalRecords = String.Empty;
        //    var result = new ReturnResult<User>();
        //    try
        //    {
        //        provider.SetQuery("User_GetAllPagingOutside", System.Data.CommandType.StoredProcedure)
        //            .SetParameter("PageIndex", SqlDbType.Int, condition.PageIndex)
        //            .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
        //            .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
        //            .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
        //            .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<User>(out list).Complete();

        //        if (list.Count > 0)
        //        {
        //            result.ItemList = list;
        //        }
        //        provider.GetOutValue("ErrorCode", out outCode)
        //                   .GetOutValue("ErrorMessage", out outMessage)
        //                   .GetOutValue("TotalRecords", out string totalRows);

        //        if (outCode != "0")
        //        {
        //            result.ErrorCode = outCode;
        //            result.ErrorMessage = outMessage;
        //        }
        //        else
        //        {
        //            result.ErrorCode = "";
        //            result.ErrorMessage = "";
        //            result.TotalRows = int.Parse(totalRows);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Failed("-1", ex.Message);
        //    }
        //    return result;
        //}

        public ReturnResult<User> Login(string username, string password)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<User>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            User item = new User();
            try
            {
                provider.SetQuery("Users_Login", CommandType.StoredProcedure)
                    .SetParameter("Username", SqlDbType.NVarChar, username, ParameterDirection.Input)
                    .SetParameter("Password", SqlDbType.NVarChar, password, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                    .GetSingle<User>(out item).Complete();

                provider.GetOutValue("ErrorCode", out outCode)
                          .GetOutValue("ErrorMessage", out outMessage);

                if (outCode != "0" || outCode == "")
                {
                    result.ErrorCode = outCode;
                    result.ErrorMessage = outMessage;
                }
                else
                {
                    result.Item = item;
                    result.ErrorCode = outCode;
                    result.ErrorMessage = outMessage;
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }

            return result;
        }
        //public ReturnResult<User> DeleteUser(int id)
        //{
        //    DbProvider provider = new DbProvider();
        //    var result = new ReturnResult<User>();
        //    string outCode = String.Empty;
        //    string outMessage = String.Empty;
        //    string totalRecords = String.Empty;
        //    User item = new User();
        //    try
        //    {
        //        provider.SetQuery("User_Delete", CommandType.StoredProcedure)
        //            .SetParameter("Id", SqlDbType.Int, id, System.Data.ParameterDirection.Input)
        //            .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, System.Data.ParameterDirection.Output)
        //            .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, System.Data.ParameterDirection.Output)
        //            .ExcuteNonQuery().Complete();

        //        provider.GetOutValue("ErrorCode", out outCode)
        //                  .GetOutValue("ErrorMessage", out outMessage);

        //        if (outCode != "0")
        //        {
        //            result.Failed(outCode, outMessage);
        //        }
        //        else
        //        {
        //            result.ErrorCode = "0";
        //            result.ErrorMessage = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return result;
        //}
        //public ReturnResult<User> UpdateUser(User User)
        //{
        //    ReturnResult<User> result = new ReturnResult<User>(); ;
        //    DbProvider db;
        //    try
        //    {
        //        db = new DbProvider();
        //        db.SetQuery("User_Update", CommandType.StoredProcedure);
        //        db.SetParameter("Id", SqlDbType.Int, User.Id)
        //        .SetParameter("Name", SqlDbType.NVarChar, User.Name)
        //        .SetParameter("ContentUser", SqlDbType.NVarChar, User.ContentUser)
        //        .SetParameter("StartDate", SqlDbType.DateTime, User.StartDate)
        //        .SetParameter("EndDate", SqlDbType.DateTime, User.EndDate)
        //        .SetParameter("ModifiedUser", SqlDbType.NVarChar, User.UserId)
        //        .SetParameter("ImageUrl", SqlDbType.NVarChar, User.ImageUrl)
        //        .SetParameter("Status", SqlDbType.TinyInt, User.Status)
        //        .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
        //        .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
        //        .ExcuteNonQuery()
        //        .Complete()
        //        .GetOutValue("ErrorCode", out string errorCode)
        //        .GetOutValue("ErrorMessage", out string errorMessage);
        //        if (errorCode.ToString() == "0")
        //        {
        //            result.ErrorCode = "0";
        //            result.ErrorMessage = "";
        //        }
        //        else
        //        {
        //            result.Failed(errorCode, errorMessage);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Failed("-1", ex.Message);
        //    }
        //    return result;
        //}
        public ReturnResult<User> Register(User User)
        {
            ReturnResult<User> result = new ReturnResult<User>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("User_Register", CommandType.StoredProcedure);
                db.SetParameter("Username", SqlDbType.NVarChar, User.Username)
                .SetParameter("Password", SqlDbType.NVarChar, User.Password)
                .SetParameter("Email", SqlDbType.NVarChar, User.Email)
                .SetParameter("Age", SqlDbType.Int, User.Age)
                .SetParameter("Gender", SqlDbType.Int, User.Gender)
                .SetParameter("StatusPayment", SqlDbType.Int, User.StatusPayment)
                .SetParameter("CreatedUser", SqlDbType.TinyInt, User.Username)
                .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                .ExcuteNonQuery()
                .Complete()
                .GetOutValue("ErrorCode", out string errorCode)
                .GetOutValue("ErrorMessage", out string errorMessage);
                if (errorCode.ToString() == "0")
                {
                    result.ErrorCode = "0";
                    result.ErrorMessage = "";
                }
                else
                {
                    result.Failed(errorCode, errorMessage);
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }
        public ReturnResult<User> GetUsersWithPaging(BaseCondition<User> condition)
        {
            DbProvider provider = new DbProvider();
            List<User> list = new List<User>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<User>();
            try
            {
                provider.SetQuery("Users_GetAllWithPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("PageIndex", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<User>(out list).Complete();

                if (list.Count > 0)
                {
                    result.ItemList = list;
                }
                provider.GetOutValue("ErrorCode", out outCode)
                           .GetOutValue("ErrorMessage", out outMessage)
                           .GetOutValue("TotalRecords", out string totalRows);

                if (outCode != "0")
                {
                    result.ErrorCode = outCode;
                    result.ErrorMessage = outMessage;
                }
                else
                {
                    result.ErrorCode = "";
                    result.ErrorMessage = "";
                    result.TotalRows = int.Parse(totalRows);
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }

    }
}
