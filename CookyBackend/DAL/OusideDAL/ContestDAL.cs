using CMSBackend.Common;
using CMSBackend.DAL;
using Common.Common;
using CookyBackend.Models.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.DAL.OusideDAL
{
    public class ContestDAL
    {
        private ContestDAL()
        {

        }
        private static ContestDAL _instance;
        public static ContestDAL ContestDALInstance()
        {
            if (_instance == null)
            {
                _instance = new ContestDAL();
            }
            return _instance;
        }

        public ReturnResult<Contest> GetContestPaging(BaseCondition<Contest> condition)
        {

            DbProvider provider = new DbProvider();
            List<Contest> list = new List<Contest>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<Contest>();
            try
            {
                provider.SetQuery("Contest_GetAllPagingOutside", System.Data.CommandType.StoredProcedure)
                    .SetParameter("PageIndex", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<Contest>(out list).Complete();

                if (list.Count > 0)
                {
                    result.ItemList = list;
                }
                provider.GetOutValue("ErrorCode", out outCode)
                           .GetOutValue("ErrorMessage", out outMessage)
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
