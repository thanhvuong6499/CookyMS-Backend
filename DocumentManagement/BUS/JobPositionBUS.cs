using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.JobPositon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class JobPositionBUS
    {
        private JobPositionDAL _instancDAL = JobPositionDAL.GetJobCategoryDALInstance();
        private JobPositionBUS()
        {

        }
        private static JobPositionBUS _instance;
        public static JobPositionBUS GetJobPositionBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new JobPositionBUS();
            }
            return _instance;
        }

        public ReturnResult<JobPosition> GetAll()
        {
            return _instancDAL.GetAllJobPosition();
        }
    }
}
