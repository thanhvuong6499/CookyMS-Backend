using CMSBackend.Common;
using CMSBackend.Models.Entity.JobCategory;
using System;
using System.Collections.Generic;
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

        public ReturnResult<JobCategory> GetAllJobCategory ()
        {
            ReturnResult<JobCategory> result = new ReturnResult<JobCategory>();
            DbProvider db = new DbProvider();
            var lstJobCategory = new List<JobCategory>();
            try
            {
                db.SetQuery("JobCategory_GetAll", System.Data.CommandType.StoredProcedure)
                    .GetList<JobCategory>(out lstJobCategory)
                    .Complete();

                if (lstJobCategory.Count > 0)
                {
                    result.ItemList = lstJobCategory;
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
    }
}
