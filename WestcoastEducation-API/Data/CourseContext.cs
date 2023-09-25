using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.Data
{
    public class CourseContext : IdentityDbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
            .HasMany(a => a.Courses)
            .WithMany(c => c.Students)
            .UsingEntity(join => join.ToTable("StudentsCourses"));

            builder.Entity<Category>()
            .HasMany(c => c.Teachers)
            .WithMany(t => t.Skills)
            .UsingEntity(join => join.ToTable("CategoriesTeachers"));

            builder.Entity<Teacher>()
            .HasMany(t => t.Courses)
            .WithMany(c => c.Teachers)
            .UsingEntity(join => join.ToTable("TeachersCourses"));

        }
    }
}