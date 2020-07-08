using CMSBackend.Common;
using CMSBackend.Models.Entity.ViewModel;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.DAL
{
    public class InsideRecruitmentNewsDAL
    {
        private InsideRecruitmentNewsDAL()
        {

        }
        private static InsideRecruitmentNewsDAL _instance;
        public static InsideRecruitmentNewsDAL GetInsideRecruitmentNewsDALInstance()
        {
            if (_instance == null)
            {
                _instance = new InsideRecruitmentNewsDAL();
            }
            return _instance;
        }
        public ReturnResult<RecruitmentNewsModel> GetRecruitmentNewsById(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<RecruitmentNewsModel>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            RecruitmentNewsModel item = new RecruitmentNewsModel();
            try
            {
                provider.SetQuery("Inside_RecruitmentNews_GetById", CommandType.StoredProcedure)
                    .SetParameter("@IN_RecruitmentId", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("@OUT_ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("@OUT_ReturnMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                    .GetSingle<RecruitmentNewsModel>(out item).Complete();

                provider.GetOutValue("@OUT_ErrorCode", out outCode)
                          .GetOutValue("@OUT_ReturnMessage", out outMessage);

                if (outCode != "0" || outCode == "")
                {
                    result.ErrorCode = outCode;
                    result.ErrorMessage = outMessage;
                }
                else
                {
                    result.Item = item;
                    result.ErrorCode = outCode;
                    result.ErrorMessage = outMessage;
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }

            return result;
        }
        public ReturnResult<RecruitmentNewsModel> InsertRecruitmentNews(RecruitmentNewsModel recruitmentNews)
        {

            var result = new ReturnResult<RecruitmentNewsModel>();
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            int outNewId = 0;
            try
            {
                // Set tên stored procedure
                db.SetQuery("Inside_RecruitmentNews_Insert", CommandType.StoredProcedure)
                .SetParameter("BranchId", SqlDbType.Int, recruitmentNews.BranchId)
                .SetParameter("JobCode", SqlDbType.NVarChar, recruitmentNews.JobCode)
                .SetParameter("AreaId", SqlDbType.Int, recruitmentNews.AreaId)
                .SetParameter("JobTypeId", SqlDbType.Int, recruitmentNews.JobTypeId)
                .SetParameter("Title", SqlDbType.NVarChar, recruitmentNews.Title)
                .SetParameter("NumberPositions", SqlDbType.SmallInt, recruitmentNews.NumberPositions)
                .SetParameter("JobPositionId", SqlDbType.Int, recruitmentNews.JobPositionId)
                .SetParameter("JobLevelId", SqlDbType.Int, recruitmentNews.JobLevelId)
                .SetParameter("MinSalary", SqlDbType.NVarChar, recruitmentNews.MinSalary)
                .SetParameter("MaxSalary", SqlDbType.NVarChar, recruitmentNews.MaxSalary)
                .SetParameter("CurrentUnit", SqlDbType.NVarChar, recruitmentNews.CurrentUnit)
                .SetParameter("ShowSalary", SqlDbType.TinyInt, recruitmentNews.ShowSalary)
                .SetParameter("JobDescription", SqlDbType.NVarChar, recruitmentNews.JobDescription)
                .SetParameter("JobRequirement", SqlDbType.NVarChar, recruitmentNews.JobRequirement)
                .SetParameter("JobFullDescription", SqlDbType.NVarChar, recruitmentNews.JobFullDescription)
                .SetParameter("JobRequest", SqlDbType.NVarChar, recruitmentNews.JobRequest)
                .SetParameter("JobBenefit", SqlDbType.NVarChar, recruitmentNews.JobBenefit)
                .SetParameter("JobInfomation", SqlDbType.NVarChar, recruitmentNews.JobInfomation)
                .SetParameter("company_name", SqlDbType.NVarChar, recruitmentNews.company_name)
                .SetParameter("company_info", SqlDbType.NVarChar, recruitmentNews.company_info)
                .SetParameter("company_logo", SqlDbType.NVarChar, recruitmentNews.company_logo)
                .SetParameter("company_size", SqlDbType.NVarChar, recruitmentNews.company_size)
                .SetParameter("JobType", SqlDbType.TinyInt, recruitmentNews.JobType)
                .SetParameter("Gender", SqlDbType.TinyInt, recruitmentNews.Gender)
                .SetParameter("AgeFrom", SqlDbType.TinyInt, recruitmentNews.AgeFrom)
                .SetParameter("AgeTo", SqlDbType.TinyInt, recruitmentNews.AgeTo)
                .SetParameter("ExamType", SqlDbType.TinyInt, recruitmentNews.ExamType)
                .SetParameter("StartDate", SqlDbType.DateTime, recruitmentNews.StartDate.ToString())
                .SetParameter("EndDate", SqlDbType.DateTime, recruitmentNews.EndDate.ToString())
                .SetParameter("Hot", SqlDbType.TinyInt, recruitmentNews.Hot)
                .SetParameter("ProcessStatus", SqlDbType.TinyInt, recruitmentNews.ProcessStatus)
                .SetParameter("CreatedUser", SqlDbType.NVarChar, recruitmentNews.CreatedUser)
                //.SetParameter("CreatedDate", SqlDbType.DateTime, recruitmentNews.CreatedDate)
                .SetParameter("YearExpMax", SqlDbType.SmallInt, recruitmentNews.YearExpMax)
                .SetParameter("YearExpMin", SqlDbType.SmallInt, recruitmentNews.YearExpMin)
                .SetParameter("FK_VacancyId", SqlDbType.Int, recruitmentNews.FK_VacancyId)
                //.SetParameter("FullTitle", SqlDbType.NVarChar, recruitmentNews.FullTitle)
                .SetParameter("BranchAddressId", SqlDbType.Int, recruitmentNews.BranchAddressId)
                .SetParameter("SkillId", SqlDbType.Int, recruitmentNews.SkillId)
                .SetParameter("JobCategoryId", SqlDbType.Int, recruitmentNews.JobCategoryId)
                // Output parameter
                .SetParameter("OUT_NewId", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                .SetParameter("OUT_ErrorCode", SqlDbType.NVarChar, DBNull.Value, 255, ParameterDirection.Output)
                .SetParameter("OUT_ReturnMessage", SqlDbType.NVarChar, DBNull.Value, 255, ParameterDirection.Output)

                // Xử lý thủ tục và kết quả trả về từ DB
                .ExcuteNonQuery()
                    .Complete();
                // Xử lý Logs

                db.GetOutValue("OUT_ErrorCode", out outCode)
                     .GetOutValue("OUT_ReturnMessage", out outMessage)
                        .GetOutValue("OUT_NewId", out outNewId);
                if (outCode != "0" || outCode == "")
                {
                    result.Failed(outCode, outMessage);

                }
                else
                {
                    recruitmentNews.RecruitmentId = outNewId;
                    result.Item = recruitmentNews;

                }
                return result;
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }
        public ReturnResult<RecruitmentNewsModel> GetRecruitmentNewPaging(BaseCondition<RecruitmentNewsModel> condition)
        {

            DbProvider provider = new DbProvider();
            List<RecruitmentNewsModel> list = new List<RecruitmentNewsModel>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalCount = String.Empty;
            var result = new ReturnResult<RecruitmentNewsModel>();
            try
            {
                provider.SetQuery("Inside_RecruitmentNews_GetAllPaging", System.Data.CommandType.StoredProcedure)
                    //.SetParameter("Contain", condition.Contain, SqlDbType.NVarChar)
                    .SetParameter("InWhere", SqlDbType.NVarChar, condition.IN_WHERE ?? String.Empty)
                    .SetParameter("InSort", SqlDbType.NVarChar, condition.IN_SORT ?? String.Empty)
                    .SetParameter("PageIndex", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalCount", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ReturnMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<RecruitmentNewsModel>(out list).Complete();

                if (list.Count > 0)
                {
                    result.ItemList = list;
                }
                provider.GetOutValue("ErrorCode", out outCode)
                           .GetOutValue("ReturnMessage", out outMessage)
                           .GetOutValue("TotalCount", out string totalRows);

                if (outCode != "0")
                {
                    result.ErrorCode = outCode;
                    result.ErrorMessage = outMessage;
                }
                else
                {
                    result.ErrorCode = "";
                    result.ErrorMessage = "";
                    result.TotalRows = int.Parse(totalRows);
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }
        public ReturnResult<RecruitmentNewsModel> UpdateRecruitmentNews(RecruitmentNewsModel recruitmentNews)
        {
            ReturnResult<RecruitmentNewsModel> result = new ReturnResult<RecruitmentNewsModel>(); ;
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            try
            {
                db = new DbProvider();
                db.SetQuery("Inside_RecruitmentNews_Update", CommandType.StoredProcedure);
                db.SetParameter("IN_RecruitmentId", SqlDbType.Int, recruitmentNews.RecruitmentId)
                .SetParameter("BranchId", SqlDbType.Int, recruitmentNews.BranchId)
                .SetParameter("JobCode", SqlDbType.NVarChar, recruitmentNews.JobCode)
                .SetParameter("BranchHrId", SqlDbType.Int, recruitmentNews.BranchHrId)
                .SetParameter("AreaId", SqlDbType.Int, recruitmentNews.AreaId)
                .SetParameter("JobTypeId", SqlDbType.Int, recruitmentNews.JobTypeId)
                .SetParameter("Title", SqlDbType.NVarChar, recruitmentNews.Title)
                .SetParameter("NumberPositions", SqlDbType.SmallInt, recruitmentNews.NumberPositions)
                .SetParameter("JobPositionId", SqlDbType.Int, recruitmentNews.JobPositionId)
                .SetParameter("JobLevelId", SqlDbType.Int, recruitmentNews.JobLevelId)
                .SetParameter("MinSalary", SqlDbType.NVarChar, recruitmentNews.MinSalary)
                .SetParameter("MaxSalary", SqlDbType.NVarChar, recruitmentNews.MaxSalary)
                .SetParameter("CurrentUnit", SqlDbType.NVarChar, recruitmentNews.CurrentUnit)
                .SetParameter("ShowSalary", SqlDbType.TinyInt, recruitmentNews.ShowSalary)
                .SetParameter("JobDescription", SqlDbType.NVarChar, recruitmentNews.JobDescription)
                .SetParameter("JobRequirement", SqlDbType.NVarChar, recruitmentNews.JobRequirement)
                .SetParameter("JobFullDescription", SqlDbType.NVarChar, recruitmentNews.JobFullDescription)
                .SetParameter("JobRequest", SqlDbType.NVarChar, recruitmentNews.JobRequest)
                .SetParameter("JobBenefit", SqlDbType.NVarChar, recruitmentNews.JobBenefit)
                .SetParameter("JobInfomation", SqlDbType.NVarChar, recruitmentNews.JobInfomation)
                .SetParameter("company_name", SqlDbType.NVarChar, recruitmentNews.company_name)
                .SetParameter("company_info", SqlDbType.NVarChar, recruitmentNews.company_info)
                .SetParameter("company_logo", SqlDbType.NVarChar, recruitmentNews.company_logo)
                .SetParameter("company_size", SqlDbType.NVarChar, recruitmentNews.company_size)
                .SetParameter("JobType", SqlDbType.TinyInt, recruitmentNews.JobType)
                .SetParameter("Gender", SqlDbType.TinyInt, recruitmentNews.Gender)
                .SetParameter("AgeFrom", SqlDbType.TinyInt, recruitmentNews.AgeFrom)
                .SetParameter("AgeTo", SqlDbType.TinyInt, recruitmentNews.AgeTo)
                .SetParameter("ExamType", SqlDbType.TinyInt, recruitmentNews.ExamType)
                .SetParameter("StartDate", SqlDbType.DateTime, recruitmentNews.StartDate.ToString())
                .SetParameter("EndDate", SqlDbType.DateTime, recruitmentNews.EndDate.ToString())
                .SetParameter("Hot", SqlDbType.TinyInt, recruitmentNews.Hot)
                .SetParameter("ProcessStatus", SqlDbType.TinyInt, recruitmentNews.ProcessStatus)
                .SetParameter("CreatedUser", SqlDbType.NVarChar, recruitmentNews.CreatedUser)
                //.SetParameter("CreatedDate", SqlDbType.DateTime, recruitmentNews.CreatedDate)
                .SetParameter("YearExpMax", SqlDbType.SmallInt, recruitmentNews.YearExpMax)
                .SetParameter("YearExpMin", SqlDbType.SmallInt, recruitmentNews.YearExpMin)
                .SetParameter("FK_VacancyId", SqlDbType.Int, recruitmentNews.FK_VacancyId)
                //.SetParameter("FullTitle", SqlDbType.NVarChar, recruitmentNews.FullTitle)
                .SetParameter("BranchAddressId", SqlDbType.Int, recruitmentNews.BranchAddressId)
                .SetParameter("SkillId", SqlDbType.Int, recruitmentNews.SkillId)
                .SetParameter("JobCategoryId", SqlDbType.Int, recruitmentNews.JobCategoryId)
                .SetParameter("OUT_NewId", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                .SetParameter("OUT_ErrorCode", SqlDbType.NVarChar, DBNull.Value, 255, ParameterDirection.Output)
                .SetParameter("OUT_ReturnMessage", SqlDbType.NVarChar, DBNull.Value, 255, ParameterDirection.Output)

                // Xử lý thủ tục và kết quả trả về từ DB
                .ExcuteNonQuery()
                    .Complete();

                db.GetOutValue("OUT_ErrorCode", out outCode)
                     .GetOutValue("OUT_ReturnMessage", out outMessage);
                        
                // Xử lý Logs
                if (outCode.ToString() == "0")
                {
                    result.ErrorCode = "0";
                    result.ErrorMessage = "";
                }
                else
                {
                    result.Failed(outCode, outMessage);
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }
    }
}
