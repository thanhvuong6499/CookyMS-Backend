using CMSBackend.Common;
using CMSBackend.Models.Entity.JobCategory;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace CMSBackend.DAL
{
    public class JobCategoryDAL
    {
        private JobCategoryDAL()
        {

        }
        private static JobCategoryDAL _instance;
        public static JobCategoryDAL GetJobCategoryDALInstance()
        {
            if (_instance == null)
            {
                _instance = new JobCategoryDAL();
            }
            return _instance;
        }

        public ReturnResult<JobCategory> GetAllJobCategory (BaseCondition<JobCategory> condition)
        {
            
            DbProvider provider = new DbProvider();
            List<JobCategory> list = new List<JobCategory>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<JobCategory>();
            try
            {
                provider.SetQuery("JobCategory_GetAll", System.Data.CommandType.StoredProcedure)
                    .SetParameter("InWhere", SqlDbType.NVarChar, condition.IN_WHERE ?? String.Empty)
                    .SetParameter("InSort", SqlDbType.NVarChar, condition.IN_SORT ?? String.Empty)
                    .SetParameter("StartRow", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<JobCategory>(out list).Complete();

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
        public ReturnResult<JobCategory> AddNewJobCategory(JobCategory jobCategory)
        {
            var result = new ReturnResult<JobCategory>();
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            try
            {
                // Set tên stored procedure
                db.SetQuery("JobCategory_AddNew", CommandType.StoredProcedure)
                .SetParameter("CategoryName", SqlDbType.NVarChar,jobCategory.CategoryName )
                .SetParameter("Description", SqlDbType.NVarChar,jobCategory.Description )
                .SetParameter("CreatedUser", SqlDbType.NVarChar, jobCategory.CreatedUser)
                .SetParameter("Status", SqlDbType.TinyInt, jobCategory.Status)
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
                    result.Item = jobCategory;
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
        public ReturnResult<JobCategory> GetJobCategoryById(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<JobCategory>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            JobCategory item = new JobCategory();
            try
            {
                provider.SetQuery("JobCategory_GetById", CommandType.StoredProcedure)
                    .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                    .GetSingle<JobCategory>(out item).Complete();

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
        public ReturnResult<JobCategory> UpdateJobCategory(JobCategory jobCategory)
        {
            ReturnResult<JobCategory> result = new ReturnResult<JobCategory>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("JobCategory_Update", CommandType.StoredProcedure);
                db.SetParameter("Id", SqlDbType.Int, jobCategory.JobCategoryId);
                db.SetParameter("CategoryName", SqlDbType.NVarChar, jobCategory.CategoryName);
                db.SetParameter("Description", SqlDbType.NVarChar, jobCategory.Description);
                db.SetParameter("ModifiedUser", SqlDbType.NVarChar, jobCategory.ModifiedDate);
                db.SetParameter("Status", SqlDbType.TinyInt, jobCategory.Status);
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
        public ReturnResult<JobCategory> DeleteJobCategory(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<JobCategory>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            JobCategory item = new JobCategory();
            try
            {
                provider.SetQuery("JobCategory_Delete", CommandType.StoredProcedure)
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
        public ReturnResult<JobCategory> GetAllJobCategory()
        {
            List<JobCategory> jobCategories = new List<JobCategory>();
            DbProvider dbProvider = new DbProvider();
            var result = new ReturnResult<JobCategory>();
            try
            {
                string outCode = String.Empty;
                string outMessage = String.Empty;
                dbProvider.SetQuery("JobCategory_GetAllData", CommandType.StoredProcedure)
                    .GetList<JobCategory>(out jobCategories)
                    .Complete();
               
                    result.ItemList = jobCategories;
  
                
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }
    }
}
