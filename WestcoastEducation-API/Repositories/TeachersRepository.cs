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
using WestcoastEducation_API.ViewModels.Category;
using WestcoastEducation_API.ViewModels.Teachers;

namespace WestcoastEducation_API.Repositories
{
  public class TeachersRepository : ITeachersRepository
  {
    private readonly CourseContext _context;
   
    public TeachersRepository(CourseContext context)
    {
      _context = context;
    }
    public async Task AddTeacherAsync(PostTeacherViewModel model)
    {
         var check= await _context.Teachers.Where(t=>t.Email==model.Email).SingleOrDefaultAsync();
         if(check is not null){ throw new Exception($"Läraren med mailet: {model.Email} Finns redan i lärarelistan");}

         var NewTeacher= new Teacher();
         NewTeacher.FirstName=model.FirstName;
         NewTeacher.LastName=model.LastName;
         NewTeacher.Email=model.Email;
         NewTeacher.Address=model.Address;
         NewTeacher.PhoneNumber=model.PhoneNumber;

         List<Category> skills=new List<Category>();
         foreach(var skill in model.skill!)
         {
           var competency= await _context.Categories.Where(c=>c.Name==skill).SingleOrDefaultAsync();
           if(competency is null)
           {
             var category = new Category();
             category.Name=skill;
           _context.Add(category);
           competency=category;

           }
           skills.Add(competency);

           NewTeacher.Skills= skills;
           await _context.Teachers.AddAsync(NewTeacher);
         }
    }

    public async Task DeleteTeacherAsync(int id)
    {
       var teacher =await _context.Teachers.FindAsync(id);
        if (teacher is null)
        {
            throw new Exception($"Vi kunde inte hitta läraren med id: {id}!");
        }
        _context.Teachers.Remove(teacher);
    }

    public async Task DeleteTeacherByEmailAsync(string email)
    {
      var teacher =await _context.Teachers.FirstOrDefaultAsync(t=>t.Email==email);
        if (teacher is null)
        {
            throw new Exception($"Vi kunde inte hitta läraren med email: {email}!");
        }
        _context.Teachers.Remove(teacher);
    }

  

    public async Task<List<TeacherViewModel>> ListTeachersAsync()
    {
    var teachers = await _context.Teachers.Include(t=>t.Skills).ToListAsync();
     List<TeacherViewModel> teachersWithSkills = new List<TeacherViewModel>(); 

     foreach(var teacher in teachers)
     {
     List<string> competencies= new List<string>();
        foreach(var skill in teacher.Skills)
        {
          competencies.Add(skill.Name!);
        }
    
     var teacherToView=new TeacherViewModel();
       teacherToView.Id=teacher.Id;
       teacherToView.Name= teacher.FirstName+" "+teacher.LastName;
       teacherToView.Email=teacher.Email;
       teacherToView.Address=teacher.Address;
       teacherToView.PhoneNumber=teacher.PhoneNumber;
       teacherToView.Email=teacher.Email;
        
       teacherToView.Skills=competencies;
  

       teachersWithSkills.Add(teacherToView);
        }
       return teachersWithSkills;
      
    }

    public async Task UpdateTeacherAsync(int id, PostTeacherViewModel model)
    {
           var teacher= await _context.Teachers.Include(t=>t.Skills).FirstOrDefaultAsync(t=>t.Id==id);
       if(teacher is null){ throw new Exception($"Vi kunde inte hitta Läraren med id: {id}!");}
         
        teacher.FirstName = model.FirstName;
        teacher.LastName=model.LastName;
        teacher.Email=model.Email;
        teacher.PhoneNumber=model.PhoneNumber;
        teacher.Address=model.Address;
        
         List<Category> skills=new List<Category>();
         foreach(var skill in model.skill!)
         {
           var competency= await _context.Categories.Where(c=>c.Name.ToLower()==skill.ToLower()).SingleOrDefaultAsync();
           if(competency is null)
           {
             var category = new Category();
             category.Name=skill;
           _context.Add(category);
           competency=category;

           }
           skills.Add(competency);

         } teacher.Skills= skills;
           _context.Teachers.Update(teacher);
    }
   

    public async Task<TeacherViewModel> GetTeacherAsync(int id)
    {
      var teacher= await _context.Teachers.Include(t=>t.Skills).Where(t=>t.Id==id).SingleOrDefaultAsync();
       if(teacher is null){
      throw new Exception($"Vi kunde inte hitta läraren med id: {id}!");}
       List<string> competencies= new List<string>();
       foreach(var skill in teacher.Skills)
       {
         competencies.Add(skill.Name!);

       }

       var teacherToView= new TeacherViewModel{
      Name=teacher.FirstName+" "+teacher.LastName,
      Email=teacher.Email,
      Address=teacher.Address,
      PhoneNumber=teacher.PhoneNumber,
      Skills=competencies
       };
      return teacherToView;  

    }

    public async Task<TeacherViewModel> GetTeacherByEmail(string email)
    {
        var teacher= await _context.Teachers.Include(t=>t.Skills).Where(t=>t.Email==email).SingleOrDefaultAsync();
       if(teacher is null){
         throw new Exception($"Vi kunde inte hitta läraren med email: {email}!");}
       List<string> competencies= new List<string>();
       foreach(var skill in teacher.Skills)
       {
         competencies.Add(skill.Name!);

       }

       var teacherToView= new TeacherViewModel{
      Name=teacher.FirstName+" "+teacher.LastName,
      Email=teacher.Email,
      Address=teacher.Address,
      PhoneNumber=teacher.PhoneNumber,
      Skills=competencies
       };
      return teacherToView; 
      
    }
    public async Task<bool> SaveAllAsync()
    {
         return await _context.SaveChangesAsync()>0;
    }
  }
}
