using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.Data
{
  public class CourseContext : DbContext
  {
    public CourseContext(DbContextOptions options) : base(options) { }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Category> Categories => Set<Category>();
    protected override void OnModelCreating(ModelBuilder builder)
    {

      builder.Entity<Student>()
      .HasMany(a => a.Courses)
      .WithMany(c => c.Students)
      .UsingEntity(join => join.ToTable("StudentsCourses"));

      base.OnModelCreating(builder);
    }

  }
}