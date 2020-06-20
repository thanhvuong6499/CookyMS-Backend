using CMSBackend.Common;
using CMSBackend.Models.Entity.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.DAL
{
    public class SkillsDAL
    {
        private SkillsDAL()
        {

        }
        private static SkillsDAL _instance;
        public static SkillsDAL GetSkillsDALInstance()
        {
            if (_instance == null)
            {
                _instance = new SkillsDAL();
            }
            return _instance;
        }

        public ReturnResult<Skills> GetAllSkills ()
        {
                ReturnResult<Skills> result = new ReturnResult<Skills>();
                DbProvider db = new DbProvider();
                var lstSkills = new List<Skills>();
                try
                {
                    db.SetQuery("Skills_GetAll", System.Data.CommandType.StoredProcedure)
                        .GetList<Skills>(out lstSkills)
                        .Complete();

                    if (lstSkills.Count > 0)
                    {
                        result.ItemList = lstSkills;
                        result.ErrorMessage = "";
                        result.ErrorCode = "0";
                    }
                }
                catch (Exception ex)
                {
                    result.Failed("-1", ex.Message);
                }

                return result;
            
        }
    }
}


