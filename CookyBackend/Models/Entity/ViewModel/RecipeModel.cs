using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.Models.Entity.ViewModel
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }
        public string ImageBackgroundUrl { get; set; }
        public int ContestId { get; set; }
        public string CreatedUser { get; set; }
        public int CreatedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int ModifiedDate { get; set; }
        public int Deleted { get; set; }
        public List<StepList> StepList { get; set; }

    }
}
