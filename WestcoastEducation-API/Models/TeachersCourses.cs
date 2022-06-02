using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.Models
{
    public class TeachersCourses
    {
        public int CouresId { get; set; }
        public int TeacherId { get; set; }
        public Course? Student { get; set; }
        public Teacher? Course { get; set; }
    }
}