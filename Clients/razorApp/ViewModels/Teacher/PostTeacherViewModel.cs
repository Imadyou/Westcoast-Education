using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels.Teacher
{
    public class PostTeacherViewModel
    {
         [Display(Name="Förnamn")]
         public string? FirstName { get; set; }
        [Display(Name="Efternamn")]
        public string? LastName { get; set; }
        [Display(Name="E-Post")]
        public string Email { get; set; }
         [Display(Name="Telefonnummer")]
        public int PhoneNumber { get; set; }
        [Display(Name="Adress")]
        public string? Address { get; set; }
         [Display(Name="Kompetenser")]
        public List<string>?Skill {get;set;}
    }
}