using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
    }
}