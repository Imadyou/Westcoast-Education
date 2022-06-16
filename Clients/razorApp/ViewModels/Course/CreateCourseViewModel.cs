using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels.Course
{
    public class CreateCourseViewModel
    {
        [Display(Name="Kurs nummer")]
        public int CourseId {get;set;}
         [Display(Name="Kurs Title")]
        public string? CourseTitle { get; set; }
         [Display(Name="Kurs Kategori")]
        public string? Subject { get; set; }
         [Display(Name="Längd")]
        public string? CourseDuration { get; set; }
         [Display(Name="Beskrivning")]
        public string? Description { get; set; }
         [Display(Name="Detaljer")]
        public string? Details { get; set; }
    }
}