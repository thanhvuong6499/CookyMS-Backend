using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.Models.Entity.ViewModel
{
    public class HomeRecruitmentNewsViewModel
{
        public int RecruitmentId { get; set; }

        public string Title { get; set; }

        public int Hot { get; set; }

        public string AreaName { get; set; }
    }
}
