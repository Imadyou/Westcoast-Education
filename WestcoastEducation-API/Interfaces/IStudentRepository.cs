using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.ViewModels.Studen;

namespace WestcoastEducation_API.Interfaces
{
    public interface IStudentRepository
    {
        public Task <List<StudentViewModel>> ListStudentsAsync();
        public Task <PostStudentViewModel> AddStudentAsync(PostStudentViewModel model);
        public Task<StudentViewModel> GetStudentAsync(int id);
        public Task <PostStudentViewModel> UpdateStudentAsync(int id ,PostStudentViewModel model);
        public Task DeleteStudentAsnc(int id);
        public Task<bool> SaveAllAsync();

    }
}