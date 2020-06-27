using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.JobCategory;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class JobCategoryBus
    {
        private JobCategoryDAL _jobCategoryDAL = JobCategoryDAL.GetJobCategoryDALInstance();
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

        public ReturnResult<JobCategory> GetAll(BaseCondition<JobCategory> condition)
        {
            return _jobCategoryDAL.GetAllJobCategory(condition);
        }
        public ReturnResult<JobCategory> AddNewJobCategory(JobCategory jobCategory)
        {
            return _jobCategoryDAL.AddNewJobCategory(jobCategory);
        }
        public ReturnResult<JobCategory> GetJobCategoryId(int id)
        {
            return _jobCategoryDAL.GetJobCategoryById(id);
        }
        public ReturnResult<JobCategory> UpdateJobCategory(JobCategory jobCategory)
        {
            return _jobCategoryDAL.UpdateJobCategory(jobCategory);
        }
        public ReturnResult<JobCategory> DeleteJobCategory(int id)
        {
            return _jobCategoryDAL.DeleteJobCategory(id);
        }
        public ReturnResult<JobCategory> GetAllJobCategory()
        {
            return _jobCategoryDAL.GetAllJobCategory();
        }
    }
}
