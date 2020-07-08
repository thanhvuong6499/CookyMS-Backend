using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.Models.Entity.ViewModel
{
    public class RecruitmentNewsModel
    {
        public int RecruitmentId { get; set; }
        public int BranchId { get; set; }
        public int BranchHrId { get; set; }

        public string JobCode { get; set; }
        public int BranchAddressId { get; set; }
        public int SkillId { get; set; }

        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int JobTypeId { get; set; }
        public string Title { get; set; }
        public string ContactPerson { get; set; }
        public int NumberPositions { get; set; }
        public int JobPositionId { get; set; }
        public int JobLevelId { get; set; }
        public string MinSalary { get; set; }
        public string MaxSalary { get; set; }
        public string CurrentUnit { get; set; }
        public int ShowSalary { get; set; }
        public string JobDescription { get; set; }
        public string JobRequirement { get; set; }
        public string JobRequest { get; set; }
        public string JobBenefit { get; set; }
        public string JobInfomation { get; set; }
        public int JobType { get; set; }
        public int Gender { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public int JobCategoryId { get; set; }
        public int CountView { get; set; }
        public int CountApply { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Hot { get; set; }
        public int HotRequest { get; set; }

        public int ExamType { get; set; }
        public int ProcessStatus { get; set; }
        public int YearExpMax { get; set; }
        public int YearExpMin { get; set; }
        public int FK_VacancyId { get; set; }
        public string FullTitle { get; set; }


        public string company_name { get; set; }
        public string company_info { get; set; }
        public string company_logo { get; set; }
        public string company_size { get; set; }
        public string JobFullDescription { get; set; }

        public string Address { get; set; }
        public string HashTags { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string BranchHrEmail { get; set; }
        public List<HomeRecruitmentNewsViewModel> RelativeList { get; set; }

        public List<BranchAddressViewModel> BranchAddresViewModels { get; set; }

        //public string EndDateStr
        //{
        //    get
        //    {
        //        if (EndDate == DateTime.MinValue)
        //        {
        //            return string.Empty;
        //        }

        //        // parse date
        //        try
        //        {
        //            return EndDate.ToString("dd.MM.yyyy", CultureInfo.CreateSpecificCulture("vi-VN"));
        //        }
        //        catch (Exception ex)
        //        {
        //            LogUtil.Error(ex.Message, ex);
        //            return string.Empty;
        //        }
        //    }
        //}

        public int DisplayFlag { get; set; }

    }
}
