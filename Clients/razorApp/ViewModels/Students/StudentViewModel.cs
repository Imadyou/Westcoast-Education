using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels.Students
{
    public class StudentViewModel
    {
        [Display(Name = ("Student-Id"))]
        public int Id { get; set; }
        [Display(Name = "Namn")]

        public string? Name { get; set; }
        [Display(Name = "E-post")]
        public string? Email { get; set; }
        [Display(Name = "TelefonNummer")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Adress")]
        public string? Address { get; set; }
    }
}