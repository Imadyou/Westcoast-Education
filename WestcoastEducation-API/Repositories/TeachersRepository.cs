using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels.Teachers;

namespace WestcoastEducation_API.Repositories
{
  public class TeachersRepository : ITeachersRepository
  {
    private readonly CourseContext _context;
    private readonly IMapper _mapper;
    public TeachersRepository(CourseContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;

    }

    public async Task AddTeacherAsync(PostTeacherViewModel model)
    {
         var NewTeacher= _mapper.Map<Teacher>(model);
         await _context.Teachers.AddAsync(NewTeacher);
    }

    public async Task DeleteTeacherAsync(int id)
    {
       var teacher =await _context.Teachers.FindAsync(id);
        if (teacher is null)
        {
            throw new Exception($"Vi kunde inte hitta studenten med id: {id}");
        }
        _context.Teachers.Remove(teacher);
    }

    public async Task<List<TeacherViewModel>> ListTeachersAsync()
    {
    return await _context.Teachers.ProjectTo<TeacherViewModel>(_mapper.ConfigurationProvider).ToListAsync();
         
    }

    public async Task<bool> SaveAllAsync()
    {
         return await _context.SaveChangesAsync()>0;
    }

    public async Task UpdateTeacherAsync(int id, TeacherViewModel model)
    {
           var teacher= await _context.Teachers.FindAsync(id);
       if(teacher is null){ throw new Exception($"Vi kunde inte hitta student med id: {id}!");}
        
        teacher.FirstName = model.FirstName;
        teacher.LastName=model.LastName;
        teacher.Email=model.Email;
        teacher.PhoneNumber=model.PhoneNumber;
        teacher.Address=model.Address;
        _context.Teachers.Update(teacher);
    }
  }
}