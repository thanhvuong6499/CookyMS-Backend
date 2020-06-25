using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.Models.Entity.Vacancy
{
    public class Vacancy
    {
        public int ID { get; set; }
        public string VacancyCode { get; set; }
        public string VacancyName { get; set; }
        public int IsActivated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public string DescriptionVN { get; set; }
    }
}
