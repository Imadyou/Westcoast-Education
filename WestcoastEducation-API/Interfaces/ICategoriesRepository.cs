using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Interfaces
{
    public interface ICategoriesRepository
    {
        public Task<List<CategoryViewModel>> ListAllcategoriesAsync();
        public Task AddCategoryAsync(PostCategoryViewModel model);
    }
}