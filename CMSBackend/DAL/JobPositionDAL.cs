using CMSBackend.Common;
using CMSBackend.Models.Entity.JobPositon;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.DAL
{
    public class JobPositionDAL
    {
        private JobPositionDAL()
        {

        }
        private static JobPositionDAL _instance;
        public static JobPositionDAL GetJobPositionDALInstance()
        {
            if (_instance == null)
            {
                _instance = new JobPositionDAL();
            }
            return _instance;
        }

        public ReturnResult<JobPosition> GetAllJobPosition()
        {
            ReturnResult<JobPosition> result = new ReturnResult<JobPosition>();
            DbProvider db = new DbProvider();
            var lstJobPosition = new List<JobPosition>();
            try
            {
                db.SetQuery("JobPosition_GetAll", System.Data.CommandType.StoredProcedure)
                    .GetList<JobPosition>(out lstJobPosition)
                    .Complete();

                if (lstJobPosition.Count > 0)
                {
                    result.ItemList = lstJobPosition;
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

        public ReturnResult<JobPosition> GetAllJobPositionWithSearchPaging(BaseCondition<JobPosition> condition)
        {

            DbProvider provider = new DbProvider();
            List<JobPosition> list = new List<JobPosition>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<JobPosition>();
            try
            {
                provider.SetQuery("JobPosition_GetAllWithSearchPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("InWhere", SqlDbType.NVarChar, condition.IN_WHERE ?? String.Empty)
                    .SetParameter("InSort", SqlDbType.NVarChar, condition.IN_SORT ?? String.Empty)
                    .SetParameter("StartRow", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<JobPosition>(out list).Complete();

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

        public ReturnResult<JobPosition> GetJobPositionById(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<JobPosition>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            JobPosition item = new JobPosition();
            try
            {
                provider.SetQuery("JobPosition_GetById", CommandType.StoredProcedure)
                    .SetParameter("JobPositionId", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                    .GetSingle<JobPosition>(out item).Complete();

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

        public ReturnResult<JobPosition> AddNewJobPosition(JobPosition JobPosition)
        {
            var result = new ReturnResult<JobPosition>();
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            try
            {
                // Set tên stored procedure
                db.SetQuery("JobPosition_AddNew", CommandType.StoredProcedure)
                .SetParameter("PositionName", SqlDbType.NVarChar, JobPosition.PositionName)
                .SetParameter("Description", SqlDbType.NVarChar, JobPosition.Description)
                .SetParameter("CreatedUser", SqlDbType.NVarChar, JobPosition.CreatedUser)
                .SetParameter("Manager", SqlDbType.TinyInt, JobPosition.Manager)
                .SetParameter("ModeifiedUser", SqlDbType.NVarChar, JobPosition.ModifiedUser)
                .SetParameter("Status", SqlDbType.TinyInt, JobPosition.Status)
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
                    result.Item = JobPosition;
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

        public ReturnResult<JobPosition> UpdateJobPosition(JobPosition JobPosition)
        {
            ReturnResult<JobPosition> result = new ReturnResult<JobPosition>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("JobPosition_Update", CommandType.StoredProcedure);
                db.SetParameter("JobPositionId", SqlDbType.Int, JobPosition.JobPositionId);
                db.SetParameter("PositionName", SqlDbType.NVarChar, JobPosition.PositionName);
                db.SetParameter("Description", SqlDbType.NVarChar, JobPosition.Description);
                db.SetParameter("Manager", SqlDbType.TinyInt, JobPosition.Manager);
                db.SetParameter("ModifiedUser", SqlDbType.NVarChar, JobPosition.ModifiedDate);
                db.SetParameter("Status", SqlDbType.TinyInt, JobPosition.Status);
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

        public ReturnResult<JobPosition> UpdateStatusJobPosition(JobPosition JobPosition)
        {
            ReturnResult<JobPosition> result = new ReturnResult<JobPosition>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("JobPosition_UpdateStatus", CommandType.StoredProcedure);
                db.SetParameter("Status", SqlDbType.TinyInt, JobPosition.Status);
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
        public ReturnResult<JobPosition> DeleteJobPosition(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<JobPosition>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            JobPosition item = new JobPosition();
            try
            {
                provider.SetQuery("JobPosition_Delete", CommandType.StoredProcedure)
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
