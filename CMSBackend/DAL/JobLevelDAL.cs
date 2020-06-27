using CMSBackend.Common;
using CMSBackend.Models.Entity.JobLevel;
using Common.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.DAL
{
    public class JobLevelDAL
    {
        private JobLevelDAL()
        {

        }
        private static JobLevelDAL _instance;
        public static JobLevelDAL GetJobLevelDALInstance()
        {
            if (_instance == null)
            {
                _instance = new JobLevelDAL();
            }
            return _instance;
        }

        public ReturnResult<JobLevel> GetAllJobLevel()
        {
            ReturnResult<JobLevel> result = new ReturnResult<JobLevel>();
            DbProvider db = new DbProvider();
            var lstJobLevel = new List<JobLevel>();
            try
            {
                db.SetQuery("JobLevel_GetAll", System.Data.CommandType.StoredProcedure)
                    .GetList<JobLevel>(out lstJobLevel)
                    .Complete();

                if (lstJobLevel.Count > 0)
                {
                    result.ItemList = lstJobLevel;
                    result.ErrorMessage = "";
                    result.ErrorCode = "0";
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }

            return result;
        }      

        public ReturnResult<JobLevel> GetAllJobLevelWithPaging(BaseCondition<JobLevel> condition)
        {

            DbProvider provider = new DbProvider();
            List<JobLevel> list = new List<JobLevel>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<JobLevel>();
            try
            {
                provider.SetQuery("JobLevel_GetAllWithSearchPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("InWhere", SqlDbType.NVarChar, condition.IN_WHERE ?? String.Empty)
                    .SetParameter("InSort", SqlDbType.NVarChar, condition.IN_SORT ?? String.Empty)
                    .SetParameter("StartRow", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<JobLevel>(out list).Complete();

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

        public ReturnResult<JobLevel> GetJobLevelById(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<JobLevel>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            JobLevel item = new JobLevel();
            try
            {
                provider.SetQuery("JobLevel_GetById", CommandType.StoredProcedure)
                    .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                    .GetSingle<JobLevel>(out item).Complete();

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

        public ReturnResult<JobLevel> AddNewJobLevel(JobLevel  jobLevel)
        {
            var result = new ReturnResult<JobLevel>();
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            try
            {
                // Set tên stored procedure
                db.SetQuery("JobLevel_AddNew", CommandType.StoredProcedure)
                .SetParameter("LevelName", SqlDbType.NVarChar, jobLevel.LevelName)
                .SetParameter("Description", SqlDbType.NVarChar, jobLevel.Description)
                .SetParameter("CreatedUser", SqlDbType.NVarChar, jobLevel.CreatedUser)
                .SetParameter("Status", SqlDbType.TinyInt, jobLevel.Status)
                .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                .ExcuteNonQuery()
                    .Complete();


                db.GetOutValue("ErrorCode", out outCode)
                    .GetOutValue("ErrorMessage", out outMessage);
                if (outCode != "0" || outCode == "")
                {
                    result.Failed(outCode, outMessage);

                }
                else
                {
                    result.Item = jobLevel;
                    result.ErrorCode = "0";
                    result.ErrorMessage = "";
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }

        public ReturnResult<JobLevel> UpdateJobLevel(JobLevel jobLevel)
        {
            ReturnResult<JobLevel> result = new ReturnResult<JobLevel>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("JobLevel_Update", CommandType.StoredProcedure);
                db.SetParameter("JobLevelId", SqlDbType.Int, jobLevel.JobLevelId);
                db.SetParameter("LevelName", SqlDbType.NVarChar, jobLevel.LevelName);
                db.SetParameter("Description", SqlDbType.NVarChar, jobLevel.Description);
                db.SetParameter("ModifiedUser", SqlDbType.NVarChar, jobLevel.ModifiedDate);
                db.SetParameter("Status", SqlDbType.TinyInt, jobLevel.Status);
                db.SetParameter("ErrorCode", SqlDbType.Int, DBNull.Value, ParameterDirection.Output);
                db.SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output);
                db.ExcuteNonQuery();
                db.Complete();
                db.GetOutValue("ErrorCode", out string errorCode);
                db.GetOutValue("ErrorMessage", out string errorMessage);
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

        public ReturnResult<JobLevel> DeleteJobLevel(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<JobLevel>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            JobLevel item = new JobLevel();
            try
            {
                provider.SetQuery("JobLevel_Delete", CommandType.StoredProcedure)
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
    }
}

