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
       var check =await _context.Students.Where(s=>s.Email!.ToLower()==model.Email!.ToLower()).SingleOrDefaultAsync();
        if(check is not null){
          throw new Exception ($" Det finns readan en eleve som har Majlet {check.Email}!");
        }
         var checkPhone= await _context.Students.Where(s=>s.PhoneNumber==model.PhoneNumber).SingleOrDefaultAsync();
          if(checkPhone is not null){ throw new Exception($"Eleven med telefonnummer: {model.PhoneNumber} Finns redan i elevlistan");}
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

    public async Task<List<StudentWithIdViewModel>> ListStudentsAsync()
    {
         return await _context.Students.ProjectTo<StudentWithIdViewModel>(_mapper.ConfigurationProvider).ToListAsync();
         
    }
    public async Task UpdateStudentAsync(int id, PostStudentViewModel model)
    {
        var student= await _context.Students.FindAsync(id);
       if(student is null){ throw new Exception($"Vi kunde inte hitta eleven med id: {id}!");}
   
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

    public async Task<StudentViewModel> GetStudentAsync(int id)
    {
         var model= await _context.Students.FindAsync(id);
         if(model is null){throw new Exception($"Vi kunde inte hitta elev med id: {id}");}
         var student = _mapper.Map<StudentViewModel>(model);
         return student;
        
    }

    public async Task<StudentViewModel?> GetStudentByEmailAsync(string email)
    {
        return await _context.Students.Include(s=>s.Courses).Where(s=>s.Email!.ToLower()==email.ToLower()).ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
    
    }
  }

}