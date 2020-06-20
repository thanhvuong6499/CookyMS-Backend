using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.JobLevel;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class JobLevelBus
    {
        private JobLevelDAL _jobLevelDAL = JobLevelDAL.GetJobLevelDALInstance();
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
            return _jobLevelDAL.GetAllJobLevel();
        }

        public ReturnResult<JobLevel> GetAllWithSearchPaging(BaseCondition<JobLevel> condition)
        {
            return _jobLevelDAL.GetAllJobLevelWithPaging(condition);
        }

        public ReturnResult<JobLevel> AddNewJobLevel(JobLevel jobLevel)
        {
            return _jobLevelDAL.AddNewJobLevel(jobLevel);
        }

        public ReturnResult<JobLevel> UpdateJobLevel(JobLevel jobLevel)
        {
            return _jobLevelDAL.UpdateJobLevel(jobLevel);
        }

        public ReturnResult<JobLevel> DeleteJobLevel(int id)
        {
            return _jobLevelDAL.DeleteJobLevel(id);
        }
    }
}
