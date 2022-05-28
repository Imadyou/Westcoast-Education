using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        // public int? CategoryId{get; set;}
        // [ForeignKey("CategoryId")]
        // public Category Category{get;set;}=new Category();
        
        // public ICollection<StudentCourse> Students { get; set; }= new List<StudentCourse>();
    }
}