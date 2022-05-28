using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.Data
{
  public class CourseContext : DbContext
    {
    public CourseContext(DbContextOptions options) : base(options) {}
    

        public DbSet <Course> Courses => Set<Course>(); 
        // public DbSet <Student> Strudents=>Set<Student>();
        // public DbSet<Teacher> Teachers =>Set<Teacher>();
        // public DbSet<StudentCourse> StudentCourses=>Set<StudentCourse>();
        public DbSet <Category> Categories=> Set<Category>();

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //   base.OnModelCreating(builder);
        //   builder.Entity<StudentCourse>().HasKey(sc=>new{sc.CourseId, sc.StudentId});
        // }
     
    }
}  