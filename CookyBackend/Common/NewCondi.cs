using Common.Common;
using CookyBackend.Models.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.Common
{
    public class NewCondi
    {
        public BaseCondition<RecipeModel> condition { get; set; }
        public int UserId { get; set; }
    }
}
