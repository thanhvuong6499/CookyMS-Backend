using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.Models.Entity.ViewModel
{
    public class Tip
    {
        public int UserId { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public int Status { get; set; }
        public string ImgUrl { get; set; }
        public string CreatedUser { get; set; }
        public int CreatedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int ModifiedDate { get; set; }
        public int Deleted { get; set; }

    }
}
