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
    public class Create : PageModel
    {
       
    private readonly ILogger<Create> _logger;
    private readonly IConfiguration _config;
    [BindProperty]
    public PostTeacherViewModel Teacher { get; set; }=new 
    PostTeacherViewModel();
       [BindProperty]
    public List<CategoryViewModel>? Categories { get; set; }=new List<CategoryViewModel>();
      public Create(ILogger<Create> logger, IConfiguration config)
        {
            _config = config;
            _logger = logger;
            
        }

        public async Task OnPostAsync()
        { 
         
           using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/teachers";
            var response = await http.PostAsJsonAsync(url, Teacher);
            if(!response.IsSuccessStatusCode){
                throw new Exception("Något gisk fel! Vi kunde inte skapa ny lärare!");
            }
           
            
        }
        public async Task OnGetAsync(){ 
            using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/categories/list";
             Categories = await http.GetFromJsonAsync<List<CategoryViewModel>>(url);
        
        }
        
       
    }
}
