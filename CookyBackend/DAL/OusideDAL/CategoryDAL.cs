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
    public class CategoryDAL
    {
        private CategoryDAL()
        {

        }
        private static CategoryDAL _instance;
        public static CategoryDAL CategoryDALInstance()
        {
            if (_instance == null)
            {
                _instance = new CategoryDAL();
            }
            return _instance;
        }

        //public ReturnResult<Category> GetCategoryPaging(BaseCondition<Category> condition)
        //{
        //    DbProvider provider = new DbProvider();
        //    List<Category> list = new List<Category>();
        //    string outCode = String.Empty;
        //    string outMessage = String.Empty;
        //    string totalRecords = String.Empty;
        //    var result = new ReturnResult<Category>();
        //    try
        //    {
        //        provider.SetQuery("Category_GetAllPagingOutside", System.Data.CommandType.StoredProcedure)
        //            .SetParameter("PageIndex", SqlDbType.Int, condition.PageIndex)
        //            .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
        //            .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
        //            .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
        //            .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<Category>(out list).Complete();

        //        if (list.Count > 0)
        //        {
        //            result.ItemList = list;
        //        }
        //        provider.GetOutValue("ErrorCode", out outCode)
        //                   .GetOutValue("ErrorMessage", out outMessage)
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
        public ReturnResult<Category> GetAllNameCategory()
        {
            List<Category> categories = new List<Category>();
            DbProvider dbProvider = new DbProvider();
            var result = new ReturnResult<Category>();
            try
            {
                string outCode = String.Empty;
                string outMessage = String.Empty;
                dbProvider.SetQuery("Category_GetAllWithIdAndName", CommandType.StoredProcedure)
                    .GetList<Category>(out categories)
                    .Complete();

                result.ItemList = categories;


            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }
        public ReturnResult<Category> GetAllIconCategory()
        {
            List<Category> categories = new List<Category>();
            DbProvider dbProvider = new DbProvider();
            var result = new ReturnResult<Category>();
            try
            {
                string outCode = String.Empty;
                string outMessage = String.Empty;
                dbProvider.SetQuery("Category_GetAllWithIcon", CommandType.StoredProcedure)
                    .GetList<Category>(out categories)
                    .Complete();

                result.ItemList = categories;


            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }
            return result;
        }
        //public ReturnResult<Category> GetCategoryById(int id)
        //{
        //    DbProvider provider = new DbProvider();
        //    var result = new ReturnResult<Category>();
        //    string outCode = String.Empty;
        //    string outMessage = String.Empty;
        //    string totalRecords = String.Empty;
        //    Category item = new Category();
        //    try
        //    {
        //        provider.SetQuery("Category_GetById", CommandType.StoredProcedure)
        //            .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
        //            .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
        //            .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
        //            .GetSingle<Category>(out item).Complete();

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
        public ReturnResult<Category> DeleteCategory(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<Category>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            Category item = new Category();
            try
            {
                provider.SetQuery("Category_Delete", CommandType.StoredProcedure)
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
        public ReturnResult<Category> UpdateCategory(Category category)
        {
            ReturnResult<Category> result = new ReturnResult<Category>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("Category_Update", CommandType.StoredProcedure);
                db.SetParameter("Id", SqlDbType.Int, category.Id)
                .SetParameter("Name", SqlDbType.NVarChar, category.Name)
                .SetParameter("ContentCategory", SqlDbType.NVarChar, category.Icon)
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
        public ReturnResult<Category> InsertCategory(Category category)
        {
            ReturnResult<Category> result = new ReturnResult<Category>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("Category_Insert", CommandType.StoredProcedure);
                db.SetParameter("Name", SqlDbType.NVarChar, category.Name)
                .SetParameter("ContentCategory", SqlDbType.NVarChar, category.Icon)
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
    }
}
