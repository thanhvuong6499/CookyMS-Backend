using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.Models.Entity.ViewModel
{
    public class RecipeDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }
        public int CreatedDate { get; set; }
        public List<StepList> StepList { get; set; }
        public List<MaterialList> MaterialList { get; set; }
    }
}
