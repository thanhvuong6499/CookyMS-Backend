using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.JobLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class JobLevelBus
    {
        private JobLevelDAL _instancDAL = JobLevelDAL.GetJobLevelDALInstance();
        private JobLevelBus()
        {

        }
        private static JobLevelBus _instance;
        public static JobLevelBus GetJobLevelBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new JobLevelBus();
            }
            return _instance;
        }

        public ReturnResult<JobLevel> GetAll()
        {
            return _instancDAL.GetAllJobLevel();
        }
    }
}
