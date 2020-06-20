using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class SkillsBus
    {
        private SkillsDAL _instancDAL = SkillsDAL.GetSkillsDALInstance();
        private SkillsBus()
        {

        }
        private static SkillsBus _instance;
        public static SkillsBus GetSkillsBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new SkillsBus();
            }
            return _instance;
        }

        public ReturnResult<Skills> GetAll()
        {
            return _instancDAL.GetAllSkills();
        }
    }
}
