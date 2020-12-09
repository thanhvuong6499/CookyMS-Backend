using CMSBackend.Common;
using Common.Common;
using CookyBackend.DAL.OusideDAL;
using CookyBackend.Models.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.BUS.Outside
{
    public class FeedbackBus
    {
        private FeedbackDAL _FeedbackDAL = FeedbackDAL.FeedbackDALInstance();
        private FeedbackBus()
        {

        }
        private static FeedbackBus _instance;
        public static FeedbackBus GetFeedbackBusInstance()
        {
            if (_instance == null)
            {
                _instance = new FeedbackBus();
            }
            return _instance;
        }

        public ReturnResult<Feedback> GetAllFeedbackPaging(BaseCondition<Feedback> condition)
        {
            return _FeedbackDAL.GetFeedbackPaging(condition);
        }

        public ReturnResult<Feedback> InsertFeedback(Feedback Feedback)
        {
            return _FeedbackDAL.InsertFeedback(Feedback);
        }
    }
}
