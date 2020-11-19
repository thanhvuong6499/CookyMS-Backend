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
    public class CategoryOutsideBus
    {
        private CategoryDAL _CategoryDAL = CategoryDAL.CategoryDALInstance();
        private CategoryOutsideBus()
        {

        }
        private static CategoryOutsideBus _instance;
        public static CategoryOutsideBus GetCategoryOutsideBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new CategoryOutsideBus();
            }
            return _instance;
        }

        //public ReturnResult<Category> GetAllCategoryPaging(BaseCondition<Category> condition)
        //{
        //    return _CategoryDAL.GetCategoryPaging(condition);
        //}

        //public ReturnResult<Category> GetCategoryId(int id)
        //{
        //    return _CategoryDAL.GetCategoryById(id);
        //}
        public ReturnResult<Category> AddNewCategory(Category Category)
        {
            return _CategoryDAL.InsertCategory(Category);
        }
        public ReturnResult<Category> UpdateCategory(Category Category)
        {
            return _CategoryDAL.UpdateCategory(Category);
        }
        public ReturnResult<Category> DeleteCategory(int id)
        {
            return _CategoryDAL.DeleteCategory(id);
        }
        public ReturnResult<Category> GetAllNameCategory()
        {
            return _CategoryDAL.GetAllNameCategory();
        }
        public ReturnResult<Category> GetAllIconCategory()
        {
            return _CategoryDAL.GetAllIconCategory();
        }
    }
}
