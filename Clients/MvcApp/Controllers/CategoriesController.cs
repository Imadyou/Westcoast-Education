using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcApp.Models;
using MvcApp.ViewModels.Categories;
using MvcApp.ViewModels.Courses;

namespace MvcApp.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
  
    private readonly IConfiguration _config;
    private readonly CategoryServiceModel _service;
    public CategoriesController(IConfiguration config)
    {
      _config = config;
       _service=new CategoryServiceModel(_config);
    }

    public async Task<IActionResult> Index()
        {  
             try
            {
                
              var categories =await _service.ListCategories();
              return View("Index",categories);
            }
            catch (Exception)
            {
                
                return StatusCode(500,"Något gick snätt! vi kunde inte hämma kategorilistan.. ");
            }
                 
        }
    
    }
}