using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.Repositories
{
  public class CourseRepository : ICourseRepository
  {
    private readonly CourseContext _context;
    public CourseRepository(CourseContext context)
    {
      _context = context;
    }

    public Task AddCourseAsync(Course model)
    {
      throw new NotImplementedException();
    }

    public void DeleteCourse(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<Course?> GetCourseAsync(int id)
    {
       return await _context.Courses.FindAsync(id);
    }

    public async Task<List<Course>> ListAllCoursesAsync()
    {
      return await _context.Courses.ToListAsync();
    }

    public Task<bool> SaveAllAsync()
    {
      throw new NotImplementedException();
    }

    public void UpdateCourse(int id, Course model)
    {
      throw new NotImplementedException();
    }
  }
}