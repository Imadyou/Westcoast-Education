using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.ViewModels.Students
{
    public class StudentWithIdViewModel
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
