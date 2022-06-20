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
    public class Create : PageModel
    {
        private readonly ILogger<Create> _logger;
    private readonly IConfiguration _config;
    [BindProperty]
    public PostStudentViewModel Student { get; set; }=new PostStudentViewModel();
        public Create(ILogger<Create> logger, IConfiguration config)
        {
            _config = config;
            _logger = logger;
            
        }

        public async Task<ActionResult> OnPostAsync()
        {  using var http=new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/students";
            var response = await http.PostAsJsonAsync(url, Student);
            if(!response.IsSuccessStatusCode){
                throw new Exception("Något gisk fel! Vi kunde inte skapa eleven!");
            }
            return RedirectToPage("Create");
        }
    }
}
 