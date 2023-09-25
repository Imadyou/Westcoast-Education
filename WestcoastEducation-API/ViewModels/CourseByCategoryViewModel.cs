using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WestcoastEducation_API.ViewModels.Category
{
    public class CourseByCategoryViewModel
    {
        public string? Subject { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Duration { get; set; }
    }
}