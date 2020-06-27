using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.JobPositon;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class JobPositionBUS
    {
        private JobPositionDAL _jobPositionDAL = JobPositionDAL.GetJobPositionDALInstance();
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
            return _jobPositionDAL.GetAllJobPosition();
        }

        public ReturnResult<JobPosition> GetAllWithSearchPaging(BaseCondition<JobPosition> condition)
        {
            return _jobPositionDAL.GetAllJobPositionWithSearchPaging(condition);
        }

        public ReturnResult<JobPosition> GetJobPositionId(int id)
        {
            return _jobPositionDAL.GetJobPositionById(id);
        }

        public ReturnResult<JobPosition> AddNewJobPosition(JobPosition JobPosition)
        {
            return _jobPositionDAL.AddNewJobPosition(JobPosition);
        }

        public ReturnResult<JobPosition> UpdateJobPosition(JobPosition JobPosition)
        {
            return _jobPositionDAL.UpdateJobPosition(JobPosition);
        }

        public ReturnResult<JobPosition> UpdateStatusJobPosition(JobPosition JobPosition)
        {
            return _jobPositionDAL.UpdateStatusJobPosition(JobPosition);
        }

        public ReturnResult<JobPosition> DeleteJobPosition(int id)
        {
            return _jobPositionDAL.DeleteJobPosition(id);
        }
    }
}
