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
using WestcoastEducation_API.ViewModels;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Repositories
{
  public class CourseRepository : ICourseRepository
  {
    private readonly CourseContext _context;
    private readonly IMapper _mapper;
    public CourseRepository(CourseContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;

    }

    public async Task AddCourseAsync(PostCourseViewModel model)
    {
      var subject= await _context.Categories
      .Include(c=>c.Courses).Where(ca=>ca.Name!.ToLower()==model.Subject!.ToLower()).SingleOrDefaultAsync();
      if(subject is not null){
      
      var courseToAdd = _mapper.Map<Course>(model);
       courseToAdd.Category = subject;
       await _context.Courses.AddAsync(courseToAdd);    
      }
      else
      {
         var catToAdd= new Category();
        catToAdd.Name=model.Subject;
        await _context.Categories.AddAsync(catToAdd);
        await _context.SaveChangesAsync();
         var courseToAdd = _mapper.Map<Course>(model);
       courseToAdd.Category = catToAdd;
       await _context.Courses.AddAsync(courseToAdd);  
      }

    }

    public async Task DeleteCourseAsync(int id)
    {
       var response = await _context.Courses.FindAsync(id);
       if(response is not null)
       {
         _context.Courses.Remove(response);
       }
    }

    public async Task<CourseViewModel?> GetCourseAsync(int id)
    {
      return await _context.Courses.Where(c=>c.Id==id)
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
    }
       // DEn metoden ska tas bort sedan..
        public async Task<CourseViewModel?> GetCoursebyTitleAsync(string courseTitle)
        {
            return await _context.Courses.Where(c => c.Title!.ToLower() == courseTitle.ToLower())
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<List<CourseViewModel>> ListAllCoursesAsync()
    {
      return await _context.Courses.ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }
public async Task<List<CourseByCategoryViewModel>> ListCoursesByCategoryAsync(string subject)
    {
    var result= await _context.Courses.Include(ca => ca.Category)
        .Where(c => c.Category.Name!.ToLower() == subject.ToLower())
        .ProjectTo<CourseByCategoryViewModel>(_mapper.ConfigurationProvider)
        .ToListAsync();
        if(result.Count== 0)
        {
          throw new Exception($"Vi kunde inte hitta kurser som har kategori {subject}");
        }
        return result;
    }

    public async Task UpdateCourseAsync(int id, PutCourseViewModel model)
    {
        
       var subject= await _context.Categories
      .Include(c=>c.Courses).Where(ca=>ca.Name!.ToLower()==model.Subject!.ToLower()).SingleOrDefaultAsync();
       if(subject is null){throw new Exception($"Kategorin {model.Subject}  finns inte va snäll och välj en annan kategori, eller först lägg kategorin i databasen");}
      var course = await _context.Courses.FindAsync(id);
    
  
      if(course is null)
      {
        throw new Exception($" Vi kunde inte hitta någon kurs med kurs nummer {id}");  
      }
   
      course.Title=model.CourseTitle;
      course.Duration=model.CourseDuration;
      course.Description=model.Description;
      course.Details=model.Details;
      course.CategoryId=subject.Id!;
      _context.Courses.Update(course); 
    }

  // public async Task AddStudentToCourseAsync(int courseId, int studentId)
  //   {   
  //         var student= await _context.Students.FindAsync(studentId);
  //         if(student is null){throw new Exception($"Vi kune inte hitta student med Id {studentId}"); }

  //         var course= await _context.Courses.FindAsync(courseId);
  //           if(student is null){throw new Exception($"Vi kune inte hitta kursen med Id {courseId}"); }
            
  //         course!.Students.Add(student!);
  //         _context.Update(course);
               
  //   }
    
    public async Task AddStudentToCourseAsync(int courseId, string studentEmail)
    {   
          var student= await _context.Students.Where(s=>s.Email==studentEmail).SingleOrDefaultAsync();
          if(student is null){throw new Exception($"Vi kune inte hitta student med mailet {studentEmail}, kontrollera imatningen"); }

          var course= await _context.Courses.FindAsync(courseId);
            if(course is null){throw new Exception($"Vi kune inte hitta kursen med Id {courseId}"); }
            
          course!.Students.Add(student!);
          _context.Update(course);
               
    }
    public async Task<bool> SaveAllAsync()
    {
     return await _context.SaveChangesAsync()>0;
    }

   
    
  }
}