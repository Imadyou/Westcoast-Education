using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using razorApp.ViewModels.Teacher;

namespace razorApp.Pages.Views.Teachers
{
   public class Edit : PageModel
    {
        private readonly ILogger<Edit> _logger;
        private readonly IConfiguration _config;
         [BindProperty]
        public PostTeacherViewModel Teacher { get; set; }=new PostTeacherViewModel();
         [BindProperty]
          public List<CategoryViewModel>? Categories { get; set; }=new List<CategoryViewModel>();
        public Edit(ILogger<Edit> logger, IConfiguration config)
        {
            _logger = logger;
            _config=config;
        }

        public async Task<ActionResult> OnPostAsync(int id)
        {using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/teachers/{id}";
            var response= await http.PutAsJsonAsync(url,Teacher);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Något gick fel vi Kunde inte uppdatera eleven!");
            }
            return RedirectToPage("Edit");
        }
             public async Task OnGetAsync(){ 
            using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/categories/list";
             Categories = await http.GetFromJsonAsync<List<CategoryViewModel>>(url);
        
        }
    }
}
