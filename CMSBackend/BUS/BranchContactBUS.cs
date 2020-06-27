using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.BranchContact;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class BranchContactBUS
    {
        private BranchContactDAL _branchContactDAL = BranchContactDAL.GetBranchContactDALInstance();
        private BranchContactBUS()
        {

        }
        private static BranchContactBUS _instance;
        public static BranchContactBUS GetBranchContactBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new BranchContactBUS();
            }
            return _instance;
        }

        public ReturnResult<BranchContact> GetAllWithSearchPaging(BaseCondition<BranchContact> condition)
        {
            return _branchContactDAL.GetAllBranchContactWithPaging(condition);
        }

        public ReturnResult<BranchContact> GetBranchContactId(int id)
        {
            return _branchContactDAL.GetBranchContactById(id);
        }

        public ReturnResult<BranchContact> AddNewBranchContact(BranchContact BranchContact)
        {
            return _branchContactDAL.AddNewBranchContact(BranchContact);
        }

        public ReturnResult<BranchContact> UpdateBranchContact(BranchContact BranchContact)
        {
            return _branchContactDAL.UpdateBranchContact(BranchContact);
        }

        public ReturnResult<BranchContact> DeleteBranchContact(int id)
        {
            return _branchContactDAL.DeleteBranchContact(id);
        }
    }
}
