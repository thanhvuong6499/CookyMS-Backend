using CMSBackend.Common;
using CMSBackend.DAL.OusideDAL;
using CMSBackend.Models.Entity.ViewModel;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS.Outside
{
    public class RecruitmentNewsBUS
    {
        private RecruitmentNewsDAL _recruitmentNewsDAL = RecruitmentNewsDAL.GetRecruitmentNewDALInstance();
        private RecruitmentNewsBUS()
        {

        }
        private static RecruitmentNewsBUS _instance;
        public static RecruitmentNewsBUS GetRecruitmentNewsBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new RecruitmentNewsBUS();
            }
            return _instance;
        }

        public ReturnResult<RecruitmentNewsModel> GetAllRecruitmentNewsPaging(BaseCondition<RecruitmentNewsModel> condition)
        {
            return _recruitmentNewsDAL.GetRecruitmentNewPaging(condition);
        }
    }
}
