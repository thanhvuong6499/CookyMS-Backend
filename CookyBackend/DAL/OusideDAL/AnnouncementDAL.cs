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
    public class AnnouncementDAL
    {
        private AnnouncementDAL()
        {

        }
        private static AnnouncementDAL _instance;
        public static AnnouncementDAL AnnouncementDALInstance()
        {
            if (_instance == null)
            {
                _instance = new AnnouncementDAL();
            }
            return _instance;
        }

        public ReturnResult<Announcement> GetAnnouncementPaging(BaseCondition<Announcement> condition)
        {
            DbProvider provider = new DbProvider();
            List<Announcement> list = new List<Announcement>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<Announcement>();
            try
            {
                provider.SetQuery("Announcement_GetAllPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("StartRow", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<Announcement>(out list).Complete();

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

        //public ReturnResult<Announcement> GetAnnouncementById(int id)
        //{
        //    DbProvider provider = new DbProvider();
        //    var result = new ReturnResult<Announcement>();
        //    string outCode = String.Empty;
        //    string outMessage = String.Empty;
        //    string totalRecords = String.Empty;
        //    Announcement item = new Announcement();
        //    try
        //    {
        //        provider.SetQuery("Announcement_GetById", CommandType.StoredProcedure)
        //            .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
        //            .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
        //            .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
        //            .GetSingle<Announcement>(out item).Complete();

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
        public ReturnResult<Announcement> DeleteAnnouncement(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<Announcement>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            Announcement item = new Announcement();
            try
            {
                provider.SetQuery("Announcement_Delete", CommandType.StoredProcedure)
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
        public ReturnResult<Announcement> UpdateAnnouncement(Announcement Announcement)
        {
            ReturnResult<Announcement> result = new ReturnResult<Announcement>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("Announcement_Update", CommandType.StoredProcedure);
                db.SetParameter("Id", SqlDbType.Int, Announcement.Id)
                .SetParameter("Name", SqlDbType.NVarChar, Announcement.Name)
                .SetParameter("Content", SqlDbType.NVarChar, Announcement.Content)
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
        public ReturnResult<Announcement> InsertAnnouncement(Announcement Announcement)
        {
            ReturnResult<Announcement> result = new ReturnResult<Announcement>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("Announcement_Insert", CommandType.StoredProcedure);
                db.SetParameter("Name", SqlDbType.NVarChar, Announcement.Name)
                .SetParameter("Content", SqlDbType.NVarChar, Announcement.Content)
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
