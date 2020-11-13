using CMSBackend.Common;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Data;
using CookyBackend.Models.Entity.ViewModel;

namespace CMSBackend.DAL.OusideDAL
{
    public class TipsDAL
    {
        private TipsDAL()
        {

        }
        private static TipsDAL _instance;
        public static TipsDAL TipsDALInstance()
        {
            if (_instance == null)
            {
                _instance = new TipsDAL();
            }
            return _instance;
        }
        public ReturnResult<Tip> AddNewTip(Tip tip)
        {
            var result = new ReturnResult<Tip>();
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            try
            {
                // Set tên stored procedure
                db.SetQuery("Tips_Insert", CommandType.StoredProcedure)
                .SetParameter("UserId", SqlDbType.Int, tip.UserId)
                .SetParameter("Name", SqlDbType.NVarChar, tip.Name)
                .SetParameter("Description", SqlDbType.NVarChar, tip.Description)
                .SetParameter("CreatedUser", SqlDbType.NVarChar, tip.CreatedUser)
                .SetParameter("ImgUrl", SqlDbType.NVarChar, tip.ImgUrl)
                .SetParameter("Status", SqlDbType.TinyInt, tip.Status)
                .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                .ExcuteNonQuery()
                    .Complete();


                db.GetOutValue("ErrorCode", out outCode)
                    .GetOutValue("ErrorMessage", out outMessage);
                if (outCode != "0" || outCode == "")
                {
                    result.Failed(outCode, outMessage);

                }
                else
                {
                    result.Item = tip;
                    result.ErrorCode = "0";
                    result.ErrorMessage = "";
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }

        //public ReturnResult<RecipeModel> GetRecipePaging(BaseCondition<RecipeModel> condition)
        //{

        //    DbProvider provider = new DbProvider();
        //    List<RecipeModel> list = new List<RecipeModel>();
        //    string outCode = String.Empty;
        //    string outMessage = String.Empty;
        //    string totalRecords = String.Empty;
        //    var result = new ReturnResult<RecipeModel>();
        //    try
        //    {
        //        provider.SetQuery("Recipe_GetAllPaging", System.Data.CommandType.StoredProcedure)
        //            .SetParameter("PageIndex", SqlDbType.Int, condition.PageIndex)
        //            .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
        //            .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
        //            .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
        //            .SetParameter("ReturnMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<RecipeModel>(out list).Complete();

        //        if (list.Count > 0)
        //        {
        //            result.ItemList = list;
        //        }
        //        provider.GetOutValue("ErrorCode", out outCode)
        //                   .GetOutValue("ReturnMessage", out outMessage)
        //                   .GetOutValue("TotalRecords", out string totalRows);

        //        if (outCode != "0")
        //        {
        //            result.ErrorCode = outCode;
        //            result.ErrorMessage = outMessage;
        //        }
        //        else
        //        {
        //            result.ErrorCode = "";
        //            result.ErrorMessage = "";
        //            result.TotalRows = int.Parse(totalRows);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Failed("-1", ex.Message);
        //    }
        //    return result;
        //}

        //public ReturnResult<RecruitmentNewsModel> GetRecruitmentNewsById(int id)
        //{
        //    DbProvider provider = new DbProvider();
        //    var result = new ReturnResult<RecruitmentNewsModel>();
        //    string outCode = String.Empty;
        //    string outMessage = String.Empty;
        //    string totalRecords = String.Empty;
        //    RecruitmentNewsModel item = new RecruitmentNewsModel();
        //    try
        //    {
        //        provider.SetQuery("Outside_RecruitmentNews_GetById", CommandType.StoredProcedure)
        //            .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
        //            .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
        //            .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
        //            .GetSingle<RecruitmentNewsModel>(out item).Complete();

        //        provider.GetOutValue("ErrorCode", out outCode)
        //                  .GetOutValue("ErrorMessage", out outMessage);

        //        if (outCode != "0" || outCode == "")
        //        {
        //            result.ErrorCode = outCode;
        //            result.ErrorMessage = outMessage;
        //        }
        //        else
        //        {
        //            result.Item = item;
        //            result.ErrorCode = outCode;
        //            result.ErrorMessage = outMessage;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Failed("-1", ex.Message);
        //    }

        //    return result;
        //}

    }
}
