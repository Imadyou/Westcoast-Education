using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.ViewModels
{
    public class PutCourseViewModel
    {
        public string? CourseTitle { get; set; }
        public string? CourseDuration { get; set; }
        public string? Details { get; set; }
        public string? Description { get; set; }
    }
}