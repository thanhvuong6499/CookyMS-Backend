using CMSBackend.Common;
using CMSBackend.Models.Entity.BranchContact;
using Common.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.DAL
{
    public class BranchContactDAL
    {
        private BranchContactDAL()
        {

        }
        private static BranchContactDAL _instance;
        public static BranchContactDAL GetBranchContactDALInstance()
        {
            if (_instance == null)
            {
                _instance = new BranchContactDAL();
            }
            return _instance;
        }

        public ReturnResult<BranchContact> GetAllBranchContact()
        {
            ReturnResult<BranchContact> result = new ReturnResult<BranchContact>();
            DbProvider db = new DbProvider();
            var lstBranchContact = new List<BranchContact>();
            try
            {
                db.SetQuery("BranchContact_GetAll", System.Data.CommandType.StoredProcedure)
                    .GetList<BranchContact>(out lstBranchContact)
                    .Complete();

                if (lstBranchContact.Count > 0)
                {
                    result.ItemList = lstBranchContact;
                    result.ErrorMessage = "";
                    result.ErrorCode = "0";
                }
            }
            catch (Exception ex)
            {
                result.Failed("-1", ex.Message);
            }

            return result;
        }

        public ReturnResult<BranchContact> GetAllBranchContactWithPaging(BaseCondition<BranchContact> condition)
        {

            DbProvider provider = new DbProvider();
            List<BranchContact> list = new List<BranchContact>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<BranchContact>();
            try
            {
                provider.SetQuery("BranchContact_GetAllWithSearchPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("InWhere", SqlDbType.NVarChar, condition.IN_WHERE ?? String.Empty)
                    .SetParameter("InSort", SqlDbType.NVarChar, condition.IN_SORT ?? String.Empty)
                    .SetParameter("StartRow", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<BranchContact>(out list).Complete();

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

        public ReturnResult<BranchContact> GetBranchContactById(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<BranchContact>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            BranchContact item = new BranchContact();
            try
            {
                provider.SetQuery("BranchContact_GetById", CommandType.StoredProcedure)
                    .SetParameter("@BranchContactId", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                    .GetSingle<BranchContact>(out item).Complete();

                provider.GetOutValue("ErrorCode", out outCode)
                          .GetOutValue("ErrorMessage", out outMessage);

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

        public ReturnResult<BranchContact> AddNewBranchContact(BranchContact BranchContact)
        {
            var result = new ReturnResult<BranchContact>();
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            try
            {
                // Set tên stored procedure
                db.SetQuery("BranchContact_AddNew", CommandType.StoredProcedure)
                .SetParameter("BranchContactCode", SqlDbType.NVarChar, BranchContact.BranchContactCode)
                .SetParameter("BranchContactName", SqlDbType.NVarChar, BranchContact.BranchContactName)
                .SetParameter("ContactName", SqlDbType.NVarChar, BranchContact.ContactName)
                .SetParameter("Email", SqlDbType.NVarChar, BranchContact.Email)
                .SetParameter("Hotline", SqlDbType.NVarChar, BranchContact.Hotline)
                .SetParameter("IPPhone", SqlDbType.NVarChar, BranchContact.IPPhone)
                .SetParameter("OperateStatus", SqlDbType.Int, BranchContact.OperateStatus)
                .SetParameter("InsertedId", SqlDbType.Int, 1)
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
                    result.Item = BranchContact;
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

        public ReturnResult<BranchContact> UpdateBranchContact(BranchContact BranchContact)
        {
            ReturnResult<BranchContact> result = new ReturnResult<BranchContact>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("BranchContact_Update", CommandType.StoredProcedure);
                db.SetParameter("BranchContactId", SqlDbType.Int, BranchContact.BranchContactId);
                db.SetParameter("BranchContactCode", SqlDbType.NVarChar, BranchContact.BranchContactCode);
                db.SetParameter("BranchContactName", SqlDbType.NVarChar, BranchContact.BranchContactName);
                db.SetParameter("ContactName", SqlDbType.NVarChar, BranchContact.ContactName);
                db.SetParameter("Email", SqlDbType.NVarChar, BranchContact.Email);
                db.SetParameter("Hotline", SqlDbType.NVarChar, BranchContact.Hotline);
                db.SetParameter("IPPhone", SqlDbType.NVarChar, BranchContact.IPPhone);
                db.SetParameter("OperateStatus", SqlDbType.Int, BranchContact.OperateStatus);
                db.SetParameter("ErrorCode", SqlDbType.Int, DBNull.Value, ParameterDirection.Output);
                db.SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output);
                db.ExcuteNonQuery();
                db.Complete();
                db.GetOutValue("ErrorCode", out string errorCode);
                db.GetOutValue("ErrorMessage", out string errorMessage);
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

        public ReturnResult<BranchContact> DeleteBranchContact(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<BranchContact>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            BranchContact item = new BranchContact();
            try
            {
                provider.SetQuery("BranchContact_Delete", CommandType.StoredProcedure)
                    .SetParameter("BranchContactId", SqlDbType.Int, id, System.Data.ParameterDirection.Input)
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
    }
}

