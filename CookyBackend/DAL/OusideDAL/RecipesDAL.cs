using CMSBackend.Common;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Data;
using CookyBackend.Models.Entity.ViewModel;

namespace CMSBackend.DAL.OusideDAL
{
    public class RecipesDAL
    {
        private RecipesDAL()
        {

        }
        private static RecipesDAL _instance;
        public static RecipesDAL RecipesDALInstance()
        {
            if (_instance == null)
            {
                _instance = new RecipesDAL();
            }
            return _instance;
        }

        public ReturnResult<RecipeModel> GetRecipePaging(BaseCondition<RecipeModel> condition)
        {

            DbProvider provider = new DbProvider();
            List<RecipeModel> list = new List<RecipeModel>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<RecipeModel>();
            try
            {
                provider.SetQuery("Recipe_GetAllPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("PageIndex", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ReturnMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<RecipeModel>(out list).Complete();

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
        public ReturnResult<RecipeModel> GetAllRecipes()
        {
            List<RecipeModel> recipes = new List<RecipeModel>();
            DbProvider dbProvider = new DbProvider();
            var result = new ReturnResult<RecipeModel>();
            try
            {
                string outCode = String.Empty;
                string outMessage = String.Empty;
                dbProvider.SetQuery("Recipes_GetAllNoPaging", CommandType.StoredProcedure)
                    .GetList<RecipeModel>(out recipes)
                    .Complete();

                result.ItemList = recipes;


            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }
    }
}
