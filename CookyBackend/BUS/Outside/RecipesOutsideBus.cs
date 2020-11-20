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
    public class RecipeOutsideBUS
    {
        private RecipesDAL _RecipesDAL = RecipesDAL.RecipesDALInstance();
        private RecipeOutsideBUS()
        {

        }
        private static RecipeOutsideBUS _instance;
        public static RecipeOutsideBUS GetRecipeOutsideBUSInstance()
        {
            if (_instance == null)
            {
                _instance = new RecipeOutsideBUS();
            }
            return _instance;
        }

        public ReturnResult<RecipeModel> GetAllRecipePaging(BaseCondition<RecipeModel> condition)
        {
            return _RecipesDAL.GetRecipePaging(condition);
        }
        public ReturnResult<RecipeModel> GetAllRecipes()
        {
            return _RecipesDAL.GetAllRecipes();
        }
        public ReturnResult<RecipeModel> AddNewRecipe(RecipeModel recipe)
        {
            return _RecipesDAL.AddNewRecipe(recipe);
        }
        public ReturnResult<RecipeModel> UpdateRecipe(RecipeModel recipe)
        {
            return _RecipesDAL.UpdateRecipe(recipe);
        }
        public ReturnResult<RecipeModel> DeleteRecipe(int id)
        {
            return _RecipesDAL.DeleteRecipe(id);
        }
        public ReturnResult<RecipeDetail> GetRecipeById(int id)
        {
            return _RecipesDAL.GetRecipeById(id);
        }
    }
}
