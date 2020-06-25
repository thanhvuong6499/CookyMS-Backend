using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.Vacancy;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class VacancyBUS
    {
        private VacancyDAL _vacancyDAL = VacancyDAL.GetVacancyDALInstance();
        private VacancyBUS()
        {

        }
        private static VacancyBUS _instance;
        public static VacancyBUS GetVacancyBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new VacancyBUS();
            }
            return _instance;
        }

        public ReturnResult<Vacancy> GetAllWithSearchPaging(BaseCondition<Vacancy> condition)
        {
            return _vacancyDAL.GetAllVacancyWithPaging(condition);
        }

        public ReturnResult<Vacancy> GetVacancyId(int id)
        {
            return _vacancyDAL.GetVacancyById(id);
        }

        public ReturnResult<Vacancy> AddNewVacancy(Vacancy Vacancy)
        {
            return _vacancyDAL.AddNewVacancy(Vacancy);
        }

        public ReturnResult<Vacancy> UpdateVacancy(Vacancy Vacancy)
        {
            return _vacancyDAL.UpdateVacancy(Vacancy);
        }

        public ReturnResult<Vacancy> DeleteVacancy(int id)
        {
            return _vacancyDAL.DeleteVacancy(id);
        }
    }
}
