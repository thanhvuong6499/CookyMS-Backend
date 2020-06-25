using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.Models.Entity.BranchContact
{
    public class BranchContact
    {
        public int BranchContactId { get; set; }
        public string BranchContactCode { get; set; }
        public string BranchContactName { get; set; }
        public string Description { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Hotline { get; set; }
        public string IPPhone { get; set; }
        public int OperateStatus { get; set; }
    }
}
