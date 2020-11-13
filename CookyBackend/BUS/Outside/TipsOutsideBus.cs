using CMSBackend.Common;
using CMSBackend.DAL.OusideDAL;
using Common.Common;
using CookyBackend.Models.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.BUS.Outside
{
    public class TipsOutsideBUS
    {
        private TipsDAL _TipsDAL = TipsDAL.TipsDALInstance();
        private TipsOutsideBUS()
        {

        }
        private static TipsOutsideBUS _instance;
        public static TipsOutsideBUS GetTipsOutsideBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new TipsOutsideBUS();
            }
            return _instance;
        }
        public ReturnResult<Tip> AddNewTip(Tip tip)
        {
            return _TipsDAL.AddNewTip(tip);
        }
        public ReturnResult<Tip> GetTipId(int id)
        {
            return _TipsDAL.GetTipById(id);
        }
        public ReturnResult<Tip> UpdateTip(Tip tip)
        {
            return _TipsDAL.UpdateTip(tip);
        }
        public ReturnResult<Tip> DeleteTip(int id)
        {
            return _TipsDAL.DeleteTip(id);
        }
        public ReturnResult<Tip> GetAllTipPaging(BaseCondition<Tip> condition)
        {
            return _TipsDAL.GetAllTipsPaging(condition);
        }

    }
}
