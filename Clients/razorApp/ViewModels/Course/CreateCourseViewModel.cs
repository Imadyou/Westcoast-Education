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
        [Required(ErrorMessage ="Kurs nummer är obligatoriskt")]
        [MinLength(4, ErrorMessage ="Kurs nummer måste var minst 4 heltal")]
        public int CourseId {get;set;}
         [Display(Name="Kurs Title")]
         [Required(ErrorMessage ="Kurs Title är obligatoriskt")]
        public string? CourseTitle { get; set; }
        [Display(Name="Kurs Kategori")]
        [Required(ErrorMessage ="Kurs Kategori är obligatorisk")]
        public string? Subject { get; set; }
         [Display(Name="Längd")]
        [Required(ErrorMessage ="Kurs Längden är obligatorisk")]
        public string? CourseDuration { get; set; }
         [Display(Name="Beskrivning")]
        public string? Description { get; set; }
         [Display(Name="Detaljer")]
        public string? Details { get; set; }
    }
}