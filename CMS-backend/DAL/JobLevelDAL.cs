using CMSBackend.Common;
using CMSBackend.Models.Entity.JobLevel;
using System;
using System.Collections.Generic;
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
    }
}

