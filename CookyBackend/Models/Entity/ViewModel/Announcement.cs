using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.Models.Entity.ViewModel
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public int Deleted { get; set; }
    }
}
