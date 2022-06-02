using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.ViewModels.Students
{
    public class StudentViewModel
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }
        public string? Address { get; set; }
        
    }
}