using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.Models
{
    public class CaegoriesTeachers
    {
        public int CategoryId { get; set; }
        public int TeacherId { get; set; }
        public Category? Category { get; set; }
        public Teacher? Teacher { get; set; }
    }
}