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
using WestcoastEducation_API.ViewModels.Students;

namespace WestcoastEducation_API.Repositories
{
  public class StudentRepository : IStudentRepository
  {
    private readonly CourseContext _context;
    private readonly IMapper _mapper;
    public StudentRepository(CourseContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;

    }

    public async Task AddStudentAsync(PostStudentViewModel model)
    {
         var NewStudent= _mapper.Map<Student>(model);
     await _context.Students.AddAsync(NewStudent);
    }

    public async Task DeleteStudentAsync(int id)
    { 
        var student =await _context.Students.FindAsync(id);
        if (student is null)
        {
            throw new Exception($"Vi kunde inte hitta studenten med id: {id}");
        }
        _context.Students.Remove(student);
       
    }

    public async Task<List<StudentViewModel>> ListStudentsAsync()
    {
         return await _context.Students.ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).ToListAsync();
         
    }
    public async Task UpdateStudentAsync(int id, StudentViewModel model)
    {
        var student= await _context.Students.FindAsync(id);
       if(student is null){ throw new Exception($"Vi kunde inte hitta student med id: {id}!");}
        
        student.FirstName = model.FirstName;
        student.LastName=model.LastName;
        student.Email=model.Email;
        student.PhoneNumber=model.PhoneNumber;
        student.Address=model.Address;
        _context.Students.Update(student);
    }


    public async Task<bool> SaveAllAsync()
    {
       return await _context.SaveChangesAsync()>0;
    }
  }

}