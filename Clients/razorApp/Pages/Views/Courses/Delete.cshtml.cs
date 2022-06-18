using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using razorApp.ViewModels.Course;

namespace razorApp.Pages.Views.Courses
{
    public class Delete : PageModel
    {
        private readonly ILogger<Delete> _logger;
 private readonly IConfiguration _config;
        [BindProperty]
        public CourseViewModel Course { get; set; }= new CourseViewModel();

        public Delete(ILogger<Delete> logger, IConfiguration config)
        {
            _logger = logger;
            _config=config;
        }

           public async Task <ActionResult> OnGetAsync(int id)
        { using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/delete/{id}";
            var response = await http.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("något gick fel vi Kunde inte Ta bort kursen!");
            }
            return RedirectToPage("./Pages/Views/Courses");
            
        }
    }
}
