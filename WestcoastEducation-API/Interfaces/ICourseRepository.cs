using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<CourseViewModel>>ListCoursesFullAsync();
        public Task<List<CourseByCategoryViewModel>>ListAllCoursesAsync();
        public Task<List<CourseByCategoryViewModel>> ListCoursesByCategoryAsync(string subject);

        public Task<List<CourseByCategoryViewModel>> ListCoursesByCategoryIdAsync(int catId);
        
        public Task<CourseViewModel?> GetCourseAsync(int id);
        public Task AddCourseAsync(PostCourseViewModel model);
        public Task UpdateCourseAsync(int id ,PutCourseViewModel model);
        public Task AddStudentToCourseAsync(int courseId, string studentEmail);
        public Task DeleteCourseAsync(int id);
        public Task<bool> SaveAllAsync();
    }
}