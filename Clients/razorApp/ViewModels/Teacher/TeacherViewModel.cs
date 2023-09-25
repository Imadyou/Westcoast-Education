using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels.Teacher
{
    public class TeacherViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Namn")]
        public string? Name { get; set; }
        [Display(Name = "E-post")]
        public string? Email { get; set; }
        [Display(Name = "Telefonnummer")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Adress")]
        public string? Address { get; set; }
        [Display(Name = "Kompetense")]
        public List<string>? Skills { get; set; }
    }
}