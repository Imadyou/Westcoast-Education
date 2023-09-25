using System.ComponentModel.DataAnnotations;

namespace WestcoastEducation_API.ViewModels
{
    public class CourseViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Subject { get; set; }
        public string? CourseDuration { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
    }
}