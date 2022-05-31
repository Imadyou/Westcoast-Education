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
      if(subject is null){
        // Om kategorien inte finns i databas skapa en ny kategori subject.
        // await _context.Categories.AddAsync(subject);
        throw new Exception($"Tyvärr vi har ingen kategori med namnet: {model.Subject}");
      }
      var courseToAdd = _mapper.Map<Course>(model);
       courseToAdd.Category = subject;
       await _context.Courses.AddAsync(courseToAdd);    
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
    return await _context.Courses.Include(ca => ca.Category)
        .Where(c => c.Category.Name!.ToLower() == subject.ToLower())
        .ProjectTo<CourseByCategoryViewModel>(_mapper.ConfigurationProvider)
        .ToListAsync();
   
    }

    public async Task UpdateCourseAsync(int id, PutCourseViewModel
 model)
    {
      var course = await _context.Courses.FindAsync(id);
      //  var subject= await _context.Categories
      // .Include(ca=>ca.Courses).Where(c=>c.Name!.ToLower()==model.Subject!.ToLower()).SingleOrDefaultAsync();
     
      if(course is null)
      {
        throw new Exception($" Vi kunde inte hitta någon kurs med kurs nummer {id}");  
      }
   
      course.Title=model.CourseTitle;
      course.Duration=model.CourseDuration;
      course.Description=model.Description;
      course.Details=model.Details;

      _context.Courses.Update(course); 
    }


    public async Task<bool> SaveAllAsync()
    {
     return await _context.SaveChangesAsync()>0;
    }

   
    
  }
}