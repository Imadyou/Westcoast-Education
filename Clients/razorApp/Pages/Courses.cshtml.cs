using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorApp.ViewModels;

namespace razorApp.Pages;

public class CoursesModel : PageModel
{
    private readonly ILogger<CoursesModel> _logger;
    private readonly IConfiguration _config;
    [BindProperty]
    public List<CategoryViewModel> Categories { get; set; }=new List<CategoryViewModel>();
    public CoursesModel(ILogger<CoursesModel> logger, IConfiguration config)
    {
        _config = config;
        _logger = logger;
    }

    public async Task OnGet()
    {
       var baseUrl = _config.GetValue<string>("baseUrl");
       var url = $"{baseUrl}/Categories/list";

       using var http= new HttpClient();
       var courses= await http.GetFromJsonAsync<List<CategoryViewModel>>(url);

    }
}

