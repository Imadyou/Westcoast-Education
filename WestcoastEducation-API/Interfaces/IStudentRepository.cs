using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.ViewModels.Students;

namespace WestcoastEducation_API.Interfaces
{
    public interface IStudentRepository
    {
        public Task<List<StudentViewModel>>ListStudentsAsync();
        public Task AddStudentAsync(PostStudentViewModel model);
        public Task UpdateStudentAsync(int id, StudentViewModel model);
        public Task DeleteStudentAsync(int id);
         public Task<bool> SaveAllAsync();
    }
}