using CMSBackend.Common;
using CMSBackend.Models.Entity.JobPositon;
using System;
using System.Collections.Generic;
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
        public static JobPositionDAL GetJobCategoryDALInstance()
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
    }

}
