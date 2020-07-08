using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.ViewModel;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class InsideRecruitmentNewsBUS
    {
        private InsideRecruitmentNewsDAL _insideRecruitmentNewsDAL = InsideRecruitmentNewsDAL.GetInsideRecruitmentNewsDALInstance();
        private InsideRecruitmentNewsBUS()
        {

        }
        private static InsideRecruitmentNewsBUS _instance;
        public static InsideRecruitmentNewsBUS GetInsideRecruitmentNewsBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new InsideRecruitmentNewsBUS();
            }
            return _instance;
        }

      
        public ReturnResult<RecruitmentNewsModel> AddNewRecruitmentNews(RecruitmentNewsModel recruitmentNews)
        {
            return _insideRecruitmentNewsDAL.InsertRecruitmentNews(recruitmentNews);
        }
        public ReturnResult<RecruitmentNewsModel> GetAllRecruitmentNewsPaging(BaseCondition<RecruitmentNewsModel> condition)
        {
            return _insideRecruitmentNewsDAL.GetRecruitmentNewPaging(condition);
        }
        public ReturnResult<RecruitmentNewsModel> GetRecruitmentNewsId(int id)
        {
            return _insideRecruitmentNewsDAL.GetRecruitmentNewsById(id);
        }
        public ReturnResult<RecruitmentNewsModel> UpdateRecruitmentNews(RecruitmentNewsModel recruitmentNews)
        {
            return _insideRecruitmentNewsDAL.UpdateRecruitmentNews(recruitmentNews);
        }
    }
}
