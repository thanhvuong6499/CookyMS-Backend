using CMSBackend.Common;
using CMSBackend.DAL;
using CMSBackend.Models.Entity.Skills;
using Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS
{
    public class SkillsBus
    {
        private SkillsDAL _skillsDAL = SkillsDAL.GetSkillsDALInstance();
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
            return _skillsDAL.GetAllSkills();
        }

        public ReturnResult<Skills> GetAllWithSearchPaging(BaseCondition<Skills> condition)
        {
            return _skillsDAL.GetAllSkillsWithPaging(condition);
        }

        public ReturnResult<Skills> GetSkillsById(int id)
        {
            return _skillsDAL.GetSkillsById(id);
        }

        public ReturnResult<Skills> AddNewSkills(Skills Skills)
        {
            return _skillsDAL.AddNewSkills(Skills);
        }

        public ReturnResult<Skills> UpdateSkills(Skills Skills)
        {
            return _skillsDAL.UpdateSkills(Skills);
        }

        public ReturnResult<Skills> DeleteSkills(int id)
        {
            return _skillsDAL.DeleteSkills(id);
        }
    }
}
