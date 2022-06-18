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
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IConfiguration _config;
         [BindProperty]
         public List<StudentViewModel>? Students { get; set; }= new List<StudentViewModel>();
        public Index(ILogger<Index> logger, IConfiguration config)
        {
      _config = config;
            _logger = logger;
            
        }

        public async Task OnGetAsync()
        {
             var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/students/list";
            using var http=new HttpClient();
              Students= await http.GetFromJsonAsync<List<StudentViewModel>>(url);
        }
    }
}
