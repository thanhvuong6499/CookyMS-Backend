using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.JobCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class JobCategoryBus
    {
        private JobCategoryDAL _instancDAL = JobCategoryDAL.GetJobCategoryDALInstance();
        private JobCategoryBus()
        {

        }
        private static JobCategoryBus _instance;
        public static JobCategoryBus GetJobCategoryBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new JobCategoryBus();
            }
            return _instance;
        }

        public ReturnResult<JobCategory> GetAll()
        {
            return _instancDAL.GetAllJobCategory();
        }
    }
}
