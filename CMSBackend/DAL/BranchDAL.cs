using CMSBackend.Common;
using CMSBackend.Models.Entity.Branch;
using Common.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.DAL
{
    public class BranchDAL
    {
        private BranchDAL()
        {

        }
        private static BranchDAL _instance;
        public static BranchDAL GetBranchDALInstance()
        {
            if (_instance == null)
            {
                _instance = new BranchDAL();
            }
            return _instance;
        }

        public ReturnResult<Branch> GetAllBranch()
        {
            ReturnResult<Branch> result = new ReturnResult<Branch>();
            DbProvider db = new DbProvider();
            var lstBranch = new List<Branch>();
            try
            {
                db.SetQuery("Branch_GetAll", System.Data.CommandType.StoredProcedure)
                    .GetList<Branch>(out lstBranch)
                    .Complete();

                if (lstBranch.Count > 0)
                {
                    result.ItemList = lstBranch;
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

        public ReturnResult<Branch> GetAllBranchWithPaging(BaseCondition<Branch> condition)
        {

            DbProvider provider = new DbProvider();
            List<Branch> list = new List<Branch>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<Branch>();
            try
            {
                provider.SetQuery("Branch_GetPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("InWhere", SqlDbType.NVarChar, condition.IN_WHERE ?? String.Empty)
                    .SetParameter("InSort", SqlDbType.NVarChar, condition.IN_SORT ?? String.Empty)
                    .SetParameter("StartRow", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<Branch>(out list)
                    .Complete();
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

        public ReturnResult<Branch> GetBranchById(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<Branch>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            Branch item = new Branch();
            try
            {
                provider.SetQuery("Branch_GetById", CommandType.StoredProcedure)
                    .SetParameter("ID", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                    .GetSingle<Branch>(out item).Complete();

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

        public ReturnResult<Branch> AddNewBranch(Branch Branch)
        {
            var result = new ReturnResult<Branch>();
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            try
            {
                // Set tên stored procedure
                db.SetQuery("Branch_Insert", CommandType.StoredProcedure)
                .SetParameter("BranchCode", SqlDbType.NVarChar, Branch.BranchCode)
                .SetParameter("BranchName", SqlDbType.NVarChar, Branch.BranchName)
                .SetParameter("Description", SqlDbType.NVarChar, Branch.Description)
                .SetParameter("CreateUser", SqlDbType.NVarChar, Branch.CreatedUser)
                .SetParameter("Status", SqlDbType.Int, Branch.Status)
                .SetParameter("BranchAddress", SqlDbType.NVarChar, Branch.BranchAddress)
                .SetParameter("BranchSize", SqlDbType.NVarChar, Branch.BranchSize)
                .SetParameter("BranchPhone", SqlDbType.NVarChar, Branch.BranchPhone)
                .SetParameter("BranchEmail", SqlDbType.NVarChar, Branch.BranchEmail)
                .SetParameter("ProvinceId", SqlDbType.NVarChar, Branch.ProvinceId)
                .SetParameter("UserId", SqlDbType.Int, Branch.UserId)
                .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                .SetParameter("ReturnMsg", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                .ExcuteNonQuery()
                    .Complete();


                db.GetOutValue("ErrorCode", out outCode)
                    .GetOutValue("ReturnMsg", out outMessage);
                if (outCode != "0" || outCode == "")
                {
                    result.ErrorCode = outCode;
                    result.ErrorMessage = outMessage;

                }
                else
                {
                    result.Item = Branch;
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

        public ReturnResult<Branch> DeleteBranch(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<Branch>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            Branch item = new Branch();
            try
            {
                provider.SetQuery("Branch_Delete", CommandType.StoredProcedure)
                    .SetParameter("ID", SqlDbType.Int, id, System.Data.ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, System.Data.ParameterDirection.Output)
                    .SetParameter("ReturnMsg", SqlDbType.NVarChar, DBNull.Value, 4000, System.Data.ParameterDirection.Output)
                    .ExcuteNonQuery().Complete();

                provider.GetOutValue("ErrorCode", out outCode)
                          .GetOutValue("ReturnMsg", out outMessage);

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

