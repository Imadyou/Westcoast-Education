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
    public class Create : PageModel
    {
        private readonly ILogger<Create> _logger;
        private readonly IConfiguration _config;
        [BindProperty]
        public CreateCourseViewModel? Course { get; set; }

        public Create(ILogger<Create> logger, IConfiguration config)
        {
             _config = config;
            _logger = logger;
        }

        public async Task OnPostAsync()
        {
            using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses";
            var response = await http.PostAsJsonAsync(url, Course);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("något gick fel vi Kunde inte spara kursen!");
            }

        }
    }
}
