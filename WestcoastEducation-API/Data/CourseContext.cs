using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.Data
{
  public class CourseContext : DbContext
    {
    public CourseContext(DbContextOptions options) : base(options) {}
    

        public DbSet <Course> Courses => Set<Course>(); // Set aktiverar ny instatnse av Course..
        public DbSet<Category> Categories => Set<Category>();
    }
}