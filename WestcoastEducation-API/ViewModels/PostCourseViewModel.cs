using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.ViewModels
{
    public class PostCourseViewModel
    {
        [Key]
        public int CourseId {get;set;}
        public string? CourseTitle { get; set; }
        public int NumberOfDays { get; set; }
        public int VideoHours { get; set; }
        // [ForeignKey("CatergoryId")]
        // public Category Category { get; set; } = new Category();
        public string? Description { get; set; }
        public string? Details { get; set; }
    }
}