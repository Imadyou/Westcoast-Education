using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.ViewModels.Teachers;

namespace WestcoastEducation_API.Interfaces
{
    public interface ITeachersRepository
    {
        public Task<List<TeacherViewModel>>ListTeachersAsync();
        public Task AddTeacherAsync(PostTeacherViewModel model);
        public Task UpdateTeacherAsync(int id, TeacherViewModel model);
        public Task DeleteTeacherAsync(int id);
        public Task<bool> SaveAllAsync();
        
    }
}