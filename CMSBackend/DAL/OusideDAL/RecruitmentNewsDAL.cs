using CMSBackend.Common;
using Common.Common;
using CMSBackend.Models.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace CMSBackend.DAL.OusideDAL
{
    public class RecruitmentNewsDAL
    {
        private RecruitmentNewsDAL()
        {

        }
        private static RecruitmentNewsDAL _instance;
        public static RecruitmentNewsDAL GetRecruitmentNewDALInstance()
        {
            if (_instance == null)
            {
                _instance = new RecruitmentNewsDAL();
            }
            return _instance;
        }

        public ReturnResult<RecruitmentNewsModel> GetRecruitmentNewPaging(BaseCondition<RecruitmentNewsModel> condition)
        {

            DbProvider provider = new DbProvider();
            List<RecruitmentNewsModel> list = new List<RecruitmentNewsModel>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<RecruitmentNewsModel>();
            try
            {
                provider.SetQuery("Outside_RecruitmentNews_GetAllPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("PageIndex", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ReturnMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<RecruitmentNewsModel>(out list).Complete();

                if (list.Count > 0)
                {
                    result.ItemList = list;
                }
                provider.GetOutValue("ErrorCode", out outCode)
                           .GetOutValue("ReturnMessage", out outMessage)
                           .GetOutValue("TotalRecords", out string totalRows);

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
    }
}
