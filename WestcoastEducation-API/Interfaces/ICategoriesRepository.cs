using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Interfaces
{
    public interface ICategoriesRepository
    {
        public Task<List<CategoryViewModel>> ListAllCategoriesAsync();
        public Task AddCategoryAsync(PostCategoryViewModel model);
        public Task DeleteCategoryAsync(int id);
        public Task<bool> SaveAllAsync();
    }
}