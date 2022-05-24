using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.Controllers
{
  [ApiController]
  [Route("api/v1/Category")]
  public class CategoryController : ControllerBase
  {
    private readonly CourseContext _context;
    public CategoryController(CourseContext context)
    {
      _context = context;
    }
    //  [HttpGet()]
    
    //     public async Task <ActionResult<List<Category>>> ListCategoriesWithCourses()
    //     {
         

    //     }

     
    
  


  }
}