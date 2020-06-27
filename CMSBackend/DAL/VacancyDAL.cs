using CMSBackend.Common;
using CMSBackend.Models.Entity.Vacancy;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.DAL
{
    public class VacancyDAL
    {
        private VacancyDAL()
        {

        }
        private static VacancyDAL _instance;
        public static VacancyDAL GetVacancyDALInstance()
        {
            if (_instance == null)
            {
                _instance = new VacancyDAL();
            }
            return _instance;
        }

        public ReturnResult<Vacancy> GetAllVacancyWithPaging(BaseCondition<Vacancy> condition)
        {

            DbProvider provider = new DbProvider();
            List<Vacancy> list = new List<Vacancy>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            var result = new ReturnResult<Vacancy>();
            try
            {
                provider.SetQuery("Vacancy_GetAllSearchWithPaging", System.Data.CommandType.StoredProcedure)
                    .SetParameter("InWhere", SqlDbType.NVarChar, condition.IN_WHERE ?? String.Empty)
                    .SetParameter("StartRow", SqlDbType.Int, condition.PageIndex)
                    .SetParameter("PageSize", SqlDbType.Int, condition.PageSize)
                    .SetParameter("TotalRecords", SqlDbType.Int, DBNull.Value, ParameterDirection.Output)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output).GetList<Vacancy>(out list).Complete();

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
        public ReturnResult<Vacancy> AddNewVacancy(Vacancy Vacancy)
        {
            var result = new ReturnResult<Vacancy>();
            DbProvider db = new DbProvider();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            try
            {
                // Set tên stored procedure
                db.SetQuery("Vacancy_AddNew", CommandType.StoredProcedure)
                .SetParameter("VacancyName", SqlDbType.NVarChar, Vacancy.VacancyName)
                .SetParameter("IsActivated", SqlDbType.Int, Vacancy.IsActivated)
                .SetParameter("VacancyCode", SqlDbType.NVarChar, Vacancy.VacancyCode)
                .SetParameter("DescriptionVN", SqlDbType.NVarChar, Vacancy.DescriptionVN)
                .SetParameter("CreatedBy", SqlDbType.NVarChar, Vacancy.CreatedBy)          
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
                    result.Item = Vacancy;
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
        public ReturnResult<Vacancy> GetVacancyById(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<Vacancy>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            Vacancy item = new Vacancy();
            try
            {
                provider.SetQuery("Vacancy_GetById", CommandType.StoredProcedure)
                    .SetParameter("Id", SqlDbType.Int, id, ParameterDirection.Input)
                    .SetParameter("ErrorCode", SqlDbType.NVarChar, DBNull.Value, 100, ParameterDirection.Output)
                    .SetParameter("ErrorMessage", SqlDbType.NVarChar, DBNull.Value, 4000, ParameterDirection.Output)
                    .GetSingle<Vacancy>(out item).Complete();

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
        public ReturnResult<Vacancy> UpdateVacancy(Vacancy Vacancy)
        {
            ReturnResult<Vacancy> result = new ReturnResult<Vacancy>(); ;
            DbProvider db;
            try
            {
                db = new DbProvider();
                db.SetQuery("Vacancy_Update", CommandType.StoredProcedure);
                db.SetParameter("Id", SqlDbType.Int, Vacancy.ID);
                db.SetParameter("VacancyName", SqlDbType.NVarChar, Vacancy.VacancyName);
                db.SetParameter("IsActivated", SqlDbType.Int, Vacancy.IsActivated);
                db.SetParameter("VacancyCode", SqlDbType.NVarChar, Vacancy.VacancyCode);
                db.SetParameter("DescriptionVN", SqlDbType.NVarChar, Vacancy.DescriptionVN);
                db.SetParameter("UpdatedBy", SqlDbType.NVarChar, Vacancy.UpdatedBy);
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
        public ReturnResult<Vacancy> DeleteVacancy(int id)
        {
            DbProvider provider = new DbProvider();
            var result = new ReturnResult<Vacancy>();
            string outCode = String.Empty;
            string outMessage = String.Empty;
            string totalRecords = String.Empty;
            Vacancy item = new Vacancy();
            try
            {
                provider.SetQuery("Vacancy_Delete", CommandType.StoredProcedure)
                    .SetParameter("Id", SqlDbType.Int, id, System.Data.ParameterDirection.Input)
                    .SetParameter("DeletedBy ", SqlDbType.NVarChar, "", System.Data.ParameterDirection.Input)
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
