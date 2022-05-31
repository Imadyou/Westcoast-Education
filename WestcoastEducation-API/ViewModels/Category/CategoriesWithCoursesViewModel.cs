using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.ViewModels.Category
{
    public class CategoriesWithCoursesViewModel
    {
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public List<CourseByCategoryViewModel> Courses { get; set; } = new List<CourseByCategoryViewModel>();
    }
}