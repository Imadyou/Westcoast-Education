using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.Models
{
    public class Student:PersonInfo
    {
        public ICollection<Course>?  Courses {get; set;}= new List<Course>();
    }
}