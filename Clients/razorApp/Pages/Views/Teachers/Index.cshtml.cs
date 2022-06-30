using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using razorApp.ViewModels.Teacher;

namespace razorApp.Pages.Views.Teachers
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        public IConfiguration _config { get; set; }
      
         [BindProperty]
        public List< TeacherViewModel>? Teachers { get; set; } 
        [BindProperty(SupportsGet =true)]
        public string? TeachersCategory {get; set;}
       

        public Index(ILogger<Index> logger, IConfiguration config)
        {
            _config = config;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
           using var http=new HttpClient();
           var baseUrl= _config.GetValue<string>("baseUrl");
           var url=$"{baseUrl}/teachers/list";
        
             Teachers= await http.GetFromJsonAsync<List<TeacherViewModel>>(url);

           if(!string.IsNullOrEmpty(TeachersCategory)){
         
           TeachersCategory= TeachersCategory.First().ToString().ToUpper() + TeachersCategory.Substring(1);
            Teachers= Teachers.Where(t=>t.Skills.Contains(TeachersCategory)).ToList();
           
           }
     
        }
          public async Task<ActionResult> OnGetDelete(int id)
        { using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Teachers/{id}";
            var response = await http.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Något gick fel vi Kunde inte Ta bort läraren!");
            }
            return RedirectToPage("Index");
            
        }

       
    }
}
