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
    public class Edit : PageModel
    {
        private readonly ILogger<Edit> _logger;
        private readonly IConfiguration _config;
        [BindProperty]
        public PutCourseViewModel Course { get; set; }= new PutCourseViewModel();

        public Edit(ILogger<Edit> logger, IConfiguration config)
        {
             _config = config;
            _logger = logger;
        }
     
        public async Task OnPostAsync(int id)
        {         
            using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/{id}";
            var response = await http.PutAsJsonAsync(url,Course);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("något gick fel vi Kunde inte spara kursen!");
            }
        }

    }
}
