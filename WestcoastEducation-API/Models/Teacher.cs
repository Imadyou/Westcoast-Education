using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.Models
{
    public class Teacher: PersonInfo
    {
        
        public ICollection<Category> Competencis { get; set; } = new List<Category>();

    }
}