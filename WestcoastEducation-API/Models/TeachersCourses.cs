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
        public Course? Course { get; set; }
        public Teacher? Teacher { get; set; }
    }
}