using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels.Students
{
    public class PostStudentViewModel
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Förnamn är obligatoriskt")]
        public string? FirstName { get; set; }
        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "EfterNamn är obligatoriskt")]
        public string? LastName { get; set; }
        [Display(Name = "E-Post")]
        [Required(ErrorMessage = "E-post är obligatoriskt")]
        [EmailAddress(ErrorMessage = "E-post adressen är ogilitig")]
        public string? Email { get; set; }
        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Telefonnummr är obligatoriskt")]
        [Phone]
        public int PhoneNumber { get; set; }
        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Adress är obligatorisk")]
        public string? Address { get; set; }
    }
}