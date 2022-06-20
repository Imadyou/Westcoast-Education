using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using razorApp.ViewModels.Students;

namespace razorApp.Pages.Views.Students
{
    public class Edit : PageModel
    {
        private readonly ILogger<Edit> _logger;
        private readonly IConfiguration _config;
         [BindProperty]
        public PostStudentViewModel Student { get; set; }=new PostStudentViewModel();
        public Edit(ILogger<Edit> logger, IConfiguration config)
        {
            _logger = logger;
            _config=config;
        }

        public async Task<ActionResult> OnPostAsync(int id)
        {using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/students/{id}";
            var response= await http.PutAsJsonAsync(url,Student);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Något gick fel vi Kunde inte uppdatera eleven!");
            }
            return RedirectToPage("Edit");
        }
    }
}
