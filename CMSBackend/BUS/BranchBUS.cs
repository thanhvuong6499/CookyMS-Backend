using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.Branch;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class BranchBUS
    {
        private BranchDAL _BranchDAL = BranchDAL.GetBranchDALInstance();
        private BranchBUS()
        {

        }
        private static BranchBUS _instance;
        public static BranchBUS GetBranchBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new BranchBUS();
            }
            return _instance;
        }

        public ReturnResult<Branch> GetAllWithSearchPaging(BaseCondition<Branch> condition)
        {
            return _BranchDAL.GetAllBranchWithPaging(condition);
        }

        public ReturnResult<Branch> GetBranchId(int id)
        {
            return _BranchDAL.GetBranchById(id);
        }

        public ReturnResult<Branch> AddNewBranch(Branch Branch)
        {
            return _BranchDAL.AddNewBranch(Branch);
        }

        public ReturnResult<Branch> DeleteBranch(int id)
        {
            return _BranchDAL.DeleteBranch(id);
        }
    }
}
