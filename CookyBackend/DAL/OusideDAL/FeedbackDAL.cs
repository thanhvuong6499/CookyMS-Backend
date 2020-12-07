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
    public class FeedbackDAL
    {
        private FeedbackDAL()
        {

        }
        private static FeedbackDAL _instance;
        public static FeedbackDAL FeedbackDALInstance()
        {
            if (_instance == null)
            {
                _instance = new FeedbackDAL();
            }
            return _instance;
        }

        public ReturnResult<Feedback> GetFeedbackPaging(BaseCondition<Feedback> condition)
        {
            DbProvider provider = new DbProvider();
            List<Feedback> list = new List<Feedback>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<Feedback>();
            try
            {
                provider.SetQuery("Feedback_GetAllWithPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("StartRow", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<Feedback>(out list).Complete();

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

        //public ReturnResult<Feedback> GetFeedbackById(int id)
        //{
        //    DbProvider provider = new DbProvider();
        //    var result = new ReturnResult<Feedback>();
        //    string outCode = String.Empty;
        //    string outMessage = String.Empty;
        //    string totalRecords = String.Empty;
        //    Feedback item = new Feedback();
        //    try
        //    {
        //        provider.SetQuery("Feedback_GetById", CommandType.StoredProcedure)
        //            .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
        //            .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
        //            .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
        //            .GetSingle<Feedback>(out item).Complete();

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
        //public ReturnResult<Feedback> DeleteFeedback(int id)
        //{
        //    DbProvider provider = new DbProvider();
        //    var result = new ReturnResult<Feedback>();
        //    string outCode = String.Empty;
        //    string outMessage = String.Empty;
        //    string totalRecords = String.Empty;
        //    Feedback item = new Feedback();
        //    try
        //    {
        //        provider.SetQuery("Feedback_Delete", CommandType.StoredProcedure)
        //            .SetParameter("Id", SqlDbType.Int, id, System.Data.ParameterDirection.Input)
        //            .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, System.Data.ParameterDirection.Output)
        //            .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, System.Data.ParameterDirection.Output)
        //            .ExcuteNonQuery().Complete();

        //        provider.GetOutValue("ErrorCode", out outCode)
        //                  .GetOutValue("ErrorMessage", out outMessage);

        //        if (outCode != "0")
        //        {
        //            result.Failed(outCode, outMessage);
        //        }
        //        else
        //        {
        //            result.ErrorCode = "0";
        //            result.ErrorMessage = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return result;
        //}
        //public ReturnResult<Feedback> UpdateFeedback(Feedback Feedback)
        //{
        //    ReturnResult<Feedback> result = new ReturnResult<Feedback>(); ;
        //    DbProvider db;
        //    try
        //    {
        //        db = new DbProvider();
        //        db.SetQuery("Feedback_Update", CommandType.StoredProcedure);
        //        db.SetParameter("Id", SqlDbType.Int, Feedback.Id)
        //        .SetParameter("Name", SqlDbType.NVarChar, Feedback.Name)
        //        .SetParameter("ContentFeedback", SqlDbType.NVarChar, Feedback.Icon)
        //        .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
        //        .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
        //        .ExcuteNonQuery()
        //        .Complete()
        //        .GetOutValue("ErrorCode", out string errorCode)
        //        .GetOutValue("ErrorMessage", out string errorMessage);
        //        if (errorCode.ToString() == "0")
        //        {
        //            result.ErrorCode = "0";
        //            result.ErrorMessage = "";
        //        }
        //        else
        //        {
        //            result.Failed(errorCode, errorMessage);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Failed("-1", ex.Message);
        //    }
        //    return result;
        //}
        public ReturnResult<Feedback> InsertFeedback(Feedback Feedback)
        {
            ReturnResult<Feedback> result = new ReturnResult<Feedback>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("Feedback_Insert", CommandType.StoredProcedure);
                db.SetParameter("UserId", SqlDbType.NVarChar, Feedback.UserId)
                .SetParameter("Content", SqlDbType.NVarChar, Feedback.FeedbackContent)
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
