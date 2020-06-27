using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.Models.DTO
{
    public class TableOfContDTO
    {
        public string TabOfContName { get; set; }
        public int TabOfContID { get; set; }
    }

    public class TableOfContSelect2
    {
        public string Text { get; set; }
        public int Id { get; set; }
    }
}
