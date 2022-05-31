using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels.Studen;

namespace WestcoastEducation_API.Repositories
{
  public class StudentRepository : IStudentRepository
  {
    private readonly CourseContext _context;
    private readonly IMapper _mapper;
    public StudentRepository(CourseContext context, IMapper mapper )
    {
      _mapper = mapper;
      _context = context;
    }

    public Task<PostStudentViewModel> AddStudentAsync(PostStudentViewModel model)
    {
      throw new NotImplementedException();
    }

    public Task DeleteStudentAsnc(int id)
    {
      throw new NotImplementedException();
    }

    public Task<StudentViewModel> GetStudentAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<StudentViewModel>> ListStudentsAsync()
    {
    //   var list= await _context.Students.FirstOrDefault(); 
    throw new NotImplementedException();
    }

    public Task<bool> SaveAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<PostStudentViewModel> UpdateStudentAsync(int id, PostStudentViewModel model)
    {
      throw new NotImplementedException();
    }
  }
}