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
    private readonly CourseServiceModel _service;
    public coursesController(IConfiguration config)
    {
      _config = config;
      _service=new CourseServiceModel(_config);
    }
[HttpGet()]
    public async Task<IActionResult> Index()
        {  
            try
            {
                
              var courses =await _service.ListCourses();
              return View("Index",courses);
            }
            catch (System.Exception)
            {
                
                throw;
            }
                 
        }

     [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        try
        {
         var course=await _service.GetCourseById(id);
         return View("Details",course);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    }
}