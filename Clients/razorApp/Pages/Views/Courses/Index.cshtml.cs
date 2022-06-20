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
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IConfiguration _config;
        [BindProperty]
        public List<CourseViewModel>? Courses{get;set;}=new List<CourseViewModel>();

        public Index(ILogger<Index> logger, IConfiguration config)
        {
      _config = config;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            try
            {
                    var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/fullList";
            using var http=new HttpClient();
             Courses= await http.GetFromJsonAsync<List<CourseViewModel>>(url);
             if(Courses is null){
                Console.WriteLine("Kurs listan är tom!");
             }
            }
            catch (Exception)
            {
                
                throw new Exception("Något gick fel när vi skulle lista kurser!");
            }
        

        }
        public async Task<ActionResult> OnGetDelete(int id)
        { using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/delete/{id}";
            var response = await http.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Något gick fel vi Kunde inte Ta bort kursen!");
            }
            return RedirectToPage("Index");
            
        }
    }
}
