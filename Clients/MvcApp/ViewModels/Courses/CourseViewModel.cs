using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MvcApp.ViewModels.Courses
{
  public class CourseViewModel
  {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Subject { get; set; }
    public string? CourseDuration { get; set; }
    public string? Description { get; set; }
    public string? Details { get; set; }

  }
}