using CMSBackend.Common;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Data;
using CookyBackend.Models.Entity.ViewModel;
using CookyBackend.Common;

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
        public ReturnResult<RecipeModel> AddNewRecipe(RecipeModel recipe)
        {
            var result = new ReturnResult<RecipeModel>();
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;

            string temp = Libs.SerializeObject(recipe.StepList);
            try
            {
                // Set tên stored procedure
                db.SetQuery("Recipe_Insert", CommandType.StoredProcedure)
                .SetParameter("UserId", SqlDbType.Int, recipe.UserId)
                .SetParameter("Name", SqlDbType.NVarChar, recipe.Name)
                .SetParameter("Note", SqlDbType.NVarChar, recipe.Note)
                .SetParameter("CategoryId", SqlDbType.Int, recipe.CategoryId)
                .SetParameter("CreatedUser", SqlDbType.NVarChar, recipe.UserId)
                .SetParameter("ImageBackgroundUrl", SqlDbType.NVarChar, recipe.ImageBackgroundUrl)
                .SetParameter("ContestId", SqlDbType.Int, recipe.ContestId)
                .SetParameter("Status", SqlDbType.TinyInt, recipe.Status)
                .SetParameter("IN_StepListJson", SqlDbType.NVarChar, Libs.SerializeObject(recipe.StepList))
                .SetParameter("IN_MaterialListJson", SqlDbType.NVarChar, Libs.SerializeObject(recipe.MaterialList))
                .SetParameter("OUT_ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                .SetParameter("OUT_ReturnMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                .ExcuteNonQuery()
                    .Complete();

                
                db.GetOutValue("OUT_ErrorCode", out outCode)
                    .GetOutValue("OUT_ReturnMessage", out outMessage);
                if (outCode != "0" || outCode == "")
                {
                    result.Failed(outCode, outMessage);

                }
                else
                {
                    result.Item = recipe;
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
        public ReturnResult<RecipeModel> UpdateRecipe(RecipeModel recipe)
        {
            ReturnResult<RecipeModel> result = new ReturnResult<RecipeModel>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("Recipe_Update", CommandType.StoredProcedure);
                db.SetParameter("Id", SqlDbType.Int, recipe.Id)
                .SetParameter("Name", SqlDbType.NVarChar, recipe.Name)
                .SetParameter("Note", SqlDbType.NVarChar, recipe.Note)
                .SetParameter("CategoryId", SqlDbType.Int, recipe.CategoryId)
                .SetParameter("ModifiedUser", SqlDbType.NVarChar, recipe.UserId)
                .SetParameter("ImageBackgroundUrl", SqlDbType.NVarChar, recipe.ImageBackgroundUrl)
                .SetParameter("Status", SqlDbType.TinyInt, recipe.Status)
                .SetParameter("IN_StepListJson", SqlDbType.NVarChar, Libs.SerializeObject(recipe.StepList))
                .SetParameter("IN_MaterialListJson", SqlDbType.NVarChar, Libs.SerializeObject(recipe.StepList))
                .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                .ExcuteNonQuery()
                .Complete()
                .GetOutValue("ErrorCode", out string errorCode)
                .GetOutValue("ErrorMessage", out string errorMessage);
                if (errorCode.ToString() == "0")
                {
                    result.ErrorCode = "0";
                    result.ErrorMessage = "";
                }
                else
                {
                    result.Failed(errorCode, errorMessage);
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }
        public ReturnResult<RecipeModel> DeleteRecipe(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<RecipeModel>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            RecipeModel item = new RecipeModel();
            try
            {
                provider.SetQuery("Recipe_Delete", CommandType.StoredProcedure)
                    .SetParameter("Id", SqlDbType.Int, id, System.Data.ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, System.Data.ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, System.Data.ParameterDirection.Output)
                    .ExcuteNonQuery().Complete();

                provider.GetOutValue("ErrorCode", out outCode)
                          .GetOutValue("ErrorMessage", out outMessage);

                if (outCode != "0")
                {
                    result.Failed(outCode, outMessage);
                }
                else
                {
                    result.ErrorCode = "0";
                    result.ErrorMessage = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public ReturnResult<RecipeDetail> GetRecipeById(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<RecipeDetail>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            RecipeDetail item = new RecipeDetail();
            try
            {
                provider.SetQuery("Recipe_GetById", CommandType.StoredProcedure)
                    .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                    .GetSingle<RecipeDetail>(out item).Complete();

                provider.GetOutValue("ErrorCode", out outCode)
                          .GetOutValue("ErrorMessage", out outMessage);
                if (outCode != "0" || outCode == "")
                {
                    result.ErrorCode = outCode;
                    result.ErrorMessage = outMessage;
                }
                else
                {
                    item.StepList = this.GetStepByRecipeId(id);
                    item.MaterialList = this.GetMaterialByRecipeId(id);
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
        public List<StepList> GetStepByRecipeId(int id)
        {

            DbProvider provider = new DbProvider();
            List<StepList> list = new List<StepList>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var resultSt = new List<StepList>();
            try
            {
                provider.SetQuery("Steps_GetByRecipeId", System.Data.CommandType.StoredProcedure)
                    .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<StepList>(out list).Complete();

                if (list.Count > 0)
                {
                    resultSt = list;
                }
                provider.GetOutValue("ErrorCode", out outCode)
                           .GetOutValue("ErrorMessage", out outMessage);
                          

                if (outCode != "0")
                {
                    //resultSt = outCode;
                    //resultSt= outMessage;
                }
                else
                {
                    //resultSt.ErrorCode = "";
                    //resultSt.ErrorMessage = "";
                    //resultSt.TotalRows = int.Parse(totalRows);
                }
            }
            catch (Exception ex)
            {
                //resultSt.Failed("-1", ex.Message);
            }
            return resultSt;
        }
        public List<MaterialList> GetMaterialByRecipeId(int id)
        {

            DbProvider provider = new DbProvider();
            List<MaterialList> list = new List<MaterialList>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var resultMt = new List<MaterialList>();
            try
            {
                provider.SetQuery("Materials_GetByRecipeId", System.Data.CommandType.StoredProcedure)
                    .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<MaterialList>(out list).Complete();

                if (list.Count > 0)
                {
                    resultMt = list;
                }
                provider.GetOutValue("ErrorCode", out outCode)
                           .GetOutValue("ErrorMessage", out outMessage);


                if (outCode != "0")
                {
                    //resultSt = outCode;
                    //resultSt= outMessage;
                }
                else
                {
                    //resultSt.ErrorCode = "";
                    //resultSt.ErrorMessage = "";
                    //resultSt.TotalRows = int.Parse(totalRows);
                }
            }
            catch (Exception ex)
            {
                //resultSt.Failed("-1", ex.Message);
            }
            return resultMt;
        }
        public ReturnResult<RecipeModel> GetRecipeByUserIdPaging(NewCondi condi)
        {

            DbProvider provider = new DbProvider();
            List<RecipeModel> list = new List<RecipeModel>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<RecipeModel>();
            try
            {
                provider.SetQuery("Recipe_GetAllByUserIdWithPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("UserId", SqlDbType.Int, condi.UserId, ParameterDirection.Input)
                    .SetParameter("PageIndex", SqlDbType.Int, condi.condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condi.condition.PageSize)
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
        public ReturnResult<RecipeModel> GetRecipesSimilar(int id)
        {
            List<RecipeModel> recipes = new List<RecipeModel>();
            DbProvider dbProvider = new DbProvider();
            var result = new ReturnResult<RecipeModel>();
            List<RecipeModel> list = new List<RecipeModel>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            try
            {
                
                dbProvider.SetQuery("Recipe_GetSimilar", CommandType.StoredProcedure)
                    .SetParameter("RecipeId", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ReturnMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<RecipeModel>(out list).Complete();

                if (list.Count > 0)
                {
                    result.ItemList = list;
                }
                dbProvider.GetOutValue("ErrorCode", out outCode)
                           .GetOutValue("ReturnMessage", out outMessage);

                if (outCode != "0")
                {
                    result.ErrorCode = outCode;
                    result.ErrorMessage = outMessage;
                }
                else
                {
                    result.ErrorCode = "";
                    result.ErrorMessage = "";
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
