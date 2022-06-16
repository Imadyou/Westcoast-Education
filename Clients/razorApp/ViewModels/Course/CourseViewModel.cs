using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels.Course
{
    public class CourseViewModel
    {
   [Display(Name="Kurs nummer")]
    public int Id { get; set; }
    [Display(Name="Kurse Title")]
    public string? Title { get; set; }
    [Display(Name="Kategori")]
    public string? Subject { get; set; }
    [Display(Name=" Kurs Längd")]
    public string? CourseDuration { get; set; }
    [Display(Name="Detaljer")]
    public string? Details { get; set; }
    [Display(Name="Beskrivning")]
    public string? Description { get; set; }
        
    }
}