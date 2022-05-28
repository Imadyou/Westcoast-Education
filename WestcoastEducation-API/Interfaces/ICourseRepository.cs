using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels;

namespace WestcoastEducation_API.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<CourseViewModel>>ListAllCoursesAsync();
        public Task<PostCourseViewModel?> GetCourseAsync(int id);
        public Task<CourseViewModel?> ListCoursebycategoryAsync(string category);
        public Task AddCourseAsync(PostCourseViewModel model);
        public Task UpdateCourse(int id ,PostCourseViewModel model);
        public Task DeleteCourse(int id);
        public Task<bool> SaveAllAsync();
    }
}