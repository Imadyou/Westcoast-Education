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
            _service = new CourseServiceModel(_config);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            try
            {

                var courses = await _service.ListCoursesByCatId(id);
                return View("Index", courses);
            }
            catch (Exception)
            {

                return StatusCode(500, "Det finns inga kurser med denna kategori ...!");
            }

        }

        [HttpGet("by/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var course = await _service.GetCourseById(id);
                return View("Details", course);
            }
            catch (Exception)
            {

                return StatusCode(500, $"Kunde inte hitta hämta kursen nummer: {id} ...!");
            }
        }

    }
}