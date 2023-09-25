using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Data
{
    public class LoadData
    {
        public static async Task LoadCategories(CourseContext context)
        {
            if (await context.Categories.AnyAsync()) return;
            var catData = await File.ReadAllTextAsync("Data/category.json");
            var categories = JsonSerializer.Deserialize<List<Category>>(catData);
            await context.AddRangeAsync(categories!);
            await context.SaveChangesAsync();

        }

        public static async Task LoadCourses(CourseContext context)
        {
            if (await context.Courses.AnyAsync()) return;
            var courseData = await File.ReadAllTextAsync("Data/course.json");
            var courses = JsonSerializer.Deserialize<List<PostCourseViewModel>>(courseData);
            if (courses is null) return;

            foreach (var course in courses)
            {
                var subject = await context.Categories.SingleOrDefaultAsync(c => c.Name.ToLower() == course.Subject!.ToLower());
                if (subject is not null)
                {
                    var newCourse = new Course()
                    {
                        Id = course.CourseId,
                        Title = course.CourseTitle,
                        Category = subject!,
                        Duration = course.CourseDuration,
                        Description = course.Description,
                        Details = course.Details
                    };
                    context.Courses.Add(newCourse);
                }


            }
            await context.SaveChangesAsync();
        }

        public static async Task LoadStudents(CourseContext context)
        {
            if (await context.Students.AnyAsync()) return;
            var studentsData = await File.ReadAllTextAsync("Data/student.json");
            var students = JsonSerializer.Deserialize<List<Student>>(studentsData);
            await context.AddRangeAsync(students!);
            await context.SaveChangesAsync();

        }

        public static async Task LoadTeachers(CourseContext context)
        {
            if (await context.Teachers.AnyAsync()) return;
            var teachersData = await File.ReadAllTextAsync("Data/teacher.json");
            var teachers = JsonSerializer.Deserialize<List<Teacher>>(teachersData);
            await context.AddRangeAsync(teachers!);
            await context.SaveChangesAsync();

        }
    }
}