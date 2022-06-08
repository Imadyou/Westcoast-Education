using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

   namespace MvcApp.ViewModels.Courses
{
    public class CourseByCategoryViewModel
    {
     public int? Name { get; set; }
     public int Id { get; set; }
    public string? Title { get; set; }
   
    public string? Duration { get; set; }
    }
}