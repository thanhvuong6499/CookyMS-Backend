using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.Models.Entity.Branch
{
    public class Branch
    {
        public int ID { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string Description { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Status { get; set; }
        public string ProvinceCode { get; set; }
        public string BranchAddress { get; set; }
        public string BranchSize { get; set; }
        public string BranchPhone { get; set; }
        public string BranchEmail { get; set; }
    }
}
