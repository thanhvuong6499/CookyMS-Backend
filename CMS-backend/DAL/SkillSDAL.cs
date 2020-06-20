using CMSBackend.Common;
using CMSBackend.Models.Entity.Skills;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.DAL
{
    public class SkillsDAL
    {
        private SkillsDAL()
        {

        }
        private static SkillsDAL _instance;
        public static SkillsDAL GetSkillsDALInstance()
        {
            if (_instance == null)
            {
                _instance = new SkillsDAL();
            }
            return _instance;
        }

        public ReturnResult<Skills> GetAllSkills ()
        {
                ReturnResult<Skills> result = new ReturnResult<Skills>();
                DbProvider db = new DbProvider();
                var lstSkills = new List<Skills>();
                try
                {
                    db.SetQuery("Skills_GetAll", System.Data.CommandType.StoredProcedure)
                        .GetList<Skills>(out lstSkills)
                        .Complete();

                    if (lstSkills.Count > 0)
                    {
                        result.ItemList = lstSkills;
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

        public ReturnResult<Skills> GetAllSkillsWithPaging(BaseCondition<Skills> condition)
        {

            DbProvider provider = new DbProvider();
            List<Skills> list = new List<Skills>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<Skills>();
            try
            {
                provider.SetQuery("Skills_GetAllWithSearchPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("InWhere", SqlDbType.NVarChar, condition.IN_WHERE ?? String.Empty)
                    .SetParameter("InSort", SqlDbType.NVarChar, condition.IN_SORT ?? String.Empty)
                    .SetParameter("StartRow", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<Skills>(out list).Complete();

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

        public ReturnResult<Skills> AddNewSkills(Skills Skills)
        {
            var result = new ReturnResult<Skills>();
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            try
            {
                // Set tên stored procedure
                db.SetQuery("Skills_AddNew", CommandType.StoredProcedure)
                .SetParameter("SkillName", SqlDbType.NVarChar, Skills.SkillName)
                .SetParameter("Description", SqlDbType.NVarChar, Skills.Description)
                .SetParameter("CreatedUser", SqlDbType.NVarChar, Skills.CreatedUser)
                .SetParameter("Status", SqlDbType.TinyInt, Skills.Status)
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
                    result.Item = Skills;
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

        public ReturnResult<Skills> UpdateSkills(Skills Skills)
        {
            ReturnResult<Skills> result = new ReturnResult<Skills>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("Skills_Update", CommandType.StoredProcedure);
                db.SetParameter("SkillId", SqlDbType.Int, Skills.SkillId);
                db.SetParameter("SkillName", SqlDbType.NVarChar, Skills.SkillName);
                db.SetParameter("Description", SqlDbType.NVarChar, Skills.Description);
                db.SetParameter("ModifiedUser", SqlDbType.NVarChar, Skills.ModifiedDate);
                db.SetParameter("Status", SqlDbType.TinyInt, Skills.Status);
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

        public ReturnResult<Skills> DeleteSkills(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<Skills>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            Skills item = new Skills();
            try
            {
                provider.SetQuery("Skills_Delete", CommandType.StoredProcedure)
                    .SetParameter("SkillId", SqlDbType.Int, id, System.Data.ParameterDirection.Input)
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


