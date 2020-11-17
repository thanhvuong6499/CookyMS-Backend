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
    public class ContestDAL
    {
        private ContestDAL()
        {

        }
        private static ContestDAL _instance;
        public static ContestDAL ContestDALInstance()
        {
            if (_instance == null)
            {
                _instance = new ContestDAL();
            }
            return _instance;
        }

        public ReturnResult<Contest> GetContestPaging(BaseCondition<Contest> condition)
        {
            DbProvider provider = new DbProvider();
            List<Contest> list = new List<Contest>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<Contest>();
            try
            {
                provider.SetQuery("Contest_GetAllPagingOutside", System.Data.CommandType.StoredProcedure)
                    .SetParameter("PageIndex", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<Contest>(out list).Complete();

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

        public ReturnResult<Contest> GetContestById(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<Contest>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            Contest item = new Contest();
            try
            {
                provider.SetQuery("Contest_GetById", CommandType.StoredProcedure)
                    .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                    .GetSingle<Contest>(out item).Complete();

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
        public ReturnResult<Contest> DeleteContest(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<Contest>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            Contest item = new Contest();
            try
            {
                provider.SetQuery("Contest_Delete", CommandType.StoredProcedure)
                    .SetParameter("Id", SqlDbType.Int, id, System.Data.ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, System.Data.ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, System.Data.ParameterDirection.Output)
                    .ExcuteNonQuery().Complete();

                provider.GetOutValue("ErrorCode", out outCode)
                          .GetOutValue("ErrorMessage", out outMessage);

                if (outCode != "0")
                {
                    result.Failed(outCode, outMessage);
                }
                else
                {
                    result.ErrorCode = "0";
                    result.ErrorMessage = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public ReturnResult<Contest> UpdateContest(Contest contest)
        {
            ReturnResult<Contest> result = new ReturnResult<Contest>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("Contest_Update", CommandType.StoredProcedure);
                db.SetParameter("Id", SqlDbType.Int, contest.Id)
                .SetParameter("Name", SqlDbType.NVarChar, contest.Name)
                .SetParameter("ContentContest", SqlDbType.NVarChar, contest.ContentContest)
                .SetParameter("StartDate", SqlDbType.DateTime, contest.StartDate)
                .SetParameter("EndDate", SqlDbType.DateTime, contest.EndDate)
                .SetParameter("ModifiedUser", SqlDbType.NVarChar, contest.UserId)
                .SetParameter("ImageUrl", SqlDbType.NVarChar, contest.ImageUrl)
                .SetParameter("Status", SqlDbType.TinyInt, contest.Status)
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
        public ReturnResult<Contest> InsertContest(Contest contest)
        {
            ReturnResult<Contest> result = new ReturnResult<Contest>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("Contest_Insert", CommandType.StoredProcedure);
                db.SetParameter("Name", SqlDbType.NVarChar, contest.Name)
                .SetParameter("ContentContest", SqlDbType.NVarChar, contest.ContentContest)
                .SetParameter("StartDate", SqlDbType.DateTime, contest.StartDate)
                .SetParameter("EndDate", SqlDbType.DateTime, contest.EndDate)
                .SetParameter("CreatedUser", SqlDbType.NVarChar, contest.UserId)
                .SetParameter("ImageUrl", SqlDbType.NVarChar, contest.ImageUrl)
                .SetParameter("Status", SqlDbType.TinyInt, contest.Status)
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
    }
}
