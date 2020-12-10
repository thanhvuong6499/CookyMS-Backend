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
    public class AnnouncementBus
    {
        private AnnouncementDAL _AnnouncementDAL = AnnouncementDAL.AnnouncementDALInstance();
        private AnnouncementBus()
        {

        }
        private static AnnouncementBus _instance;
        public static AnnouncementBus GetAnnouncementBusInstance()
        {
            if (_instance == null)
            {
                _instance = new AnnouncementBus();
            }
            return _instance;
        }

        public ReturnResult<Announcement> GetAllAnnouncementPaging(BaseCondition<Announcement> condition)
        {
            return _AnnouncementDAL.GetAnnouncementPaging(condition);
        }

        public ReturnResult<Announcement> InsertAnnouncement(Announcement Announcement)
        {
            return _AnnouncementDAL.InsertAnnouncement(Announcement);
        }
        public ReturnResult<Announcement> UpdateAnnouncement(Announcement Announcement)
        {
            return _AnnouncementDAL.UpdateAnnouncement(Announcement);
        }
        public ReturnResult<Announcement> DeleteAnnouncement(int id)
        {
            return _AnnouncementDAL.DeleteAnnouncement(id);
        }
    }
}
