using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.Models.Entity.JobPositon
{
    public class JobPosition
    {
        public int JobPositionId { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Status { get; set; }
        public int Manager { get; set; }

    }
}
