using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<Course>>ListAllCoursesAsync();
        public Task<Course?> GetCourseAsync(int id);
        public Task AddCourseAsync(Course model);
        public void UpdateCourse(int id ,Course model);
        public void DeleteCourse(int id);
        public Task<bool> SaveAllAsync();
    }
}