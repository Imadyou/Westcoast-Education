using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels.Teacher
{
    public class PostTeacherViewModel
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Förnamn är obligatoriskt")]
        public string? FirstName { get; set; }
        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "EfterNamn är obligatoriskt")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "E-post är obligatoriskt")]
        [EmailAddress(ErrorMessage = "E-post adressen är ogilitig")]
        [Display(Name = "E-Post")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Telefonnummret är obligatoriskt")]
        [Display(Name = "Telefonnummer")]

        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Adress är obligatorisk")]
        [Display(Name = "Adress")]
        public string? Address { get; set; }
        [Display(Name = "Kompetenser")]
        public List<string>? Skills { get; set; }
    }
}