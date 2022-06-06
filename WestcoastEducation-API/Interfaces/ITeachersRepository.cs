using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels.Category;
using WestcoastEducation_API.ViewModels.Teachers;

namespace WestcoastEducation_API.Interfaces
{
    public interface ITeachersRepository
    {
        public Task<List<TeacherViewModel>> ListTeachersAsync();
        public Task AddTeacherAsync(PostTeacherViewModel model);
        public Task UpdateTeacherAsync(int id, PostTeacherViewModel model);
        public Task DeleteTeacherAsync(int id);
        public Task DeleteTeacherByEmailAsync(string email);
        public Task<bool> SaveAllAsync();
        public Task<TeacherViewModel> GetTeacherAsync(int id);
        public Task<TeacherViewModel> GetTeacherByEmail(string email);
    }
}