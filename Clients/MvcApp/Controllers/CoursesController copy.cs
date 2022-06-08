using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcApp.Models;
using MvcApp.ViewModels.Courses;

namespace MvcApp.Controllers
{
    [Route("[controller]")]
    public class coursesController : Controller
    {
    private readonly IConfiguration _config;
    public coursesController(IConfiguration config)
    {
      _config = config;
    }

    public async Task<IActionResult> Index()
        {  
            try
            {
                var CourseServiceModel= new CourseServiceModel(_config);
              var courses =await CourseServiceModel.ListCourses();
              return View(courses);
            }
            catch (System.Exception)
            {
                
                throw;
            }
                 
        }

    
    }
}