using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.ViewModels
{
  public class CourseViewModel
  {

    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? CourseDuration { get; set; }
     public string? Category { get; set; }
    public string? Description { get; set; }
    public string? Details { get; set; }
  
  }
}