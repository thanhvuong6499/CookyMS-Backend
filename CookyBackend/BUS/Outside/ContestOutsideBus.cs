using CMSBackend.Common;
using Common.Common;
using CookyBackend.DAL.OusideDAL;
using CookyBackend.Models.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.BUS.Outside
{
    public class ContestOutsideBus
    {
        private ContestDAL _ContestDAL = ContestDAL.ContestDALInstance();
        private ContestOutsideBus()
        {

        }
        private static ContestOutsideBus _instance;
        public static ContestOutsideBus GetContestOutsideBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new ContestOutsideBus();
            }
            return _instance;
        }

        public ReturnResult<Contest> GetAllContestPaging(BaseCondition<Contest> condition)
        {
            return _ContestDAL.GetContestPaging(condition);
        }

        public ReturnResult<Contest> GetContestId(int id)
        {
            return _ContestDAL.GetContestById(id);
        }
        public ReturnResult<Contest> AddNewContest(Contest contest)
        {
            return _ContestDAL.InsertContest(contest);
        }
        public ReturnResult<Contest> UpdateContest(Contest contest)
        {
            return _ContestDAL.UpdateContest(contest);
        }
        public ReturnResult<Contest> DeleteRecipe(int id)
        {
            return _ContestDAL.DeleteContest(id);
        }
    }
}
