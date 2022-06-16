using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminApp.Controllers
{
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        private readonly IConfiguration _config;
        private readonly CourseServiceModel _courseService;
        public CoursesController(IConfiguration config )
        {
            _config = config;
            _courseService = new CourseServiceModel(_config);

        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            try
            {
                var courses = await _courseService.ListCoursesFull();
                return View("Index",courses);

            }
            catch (Exception)
            {

                throw new Exception("någet gisk fel när vi skulle häma kurser!");
            }
        }
    }
}
