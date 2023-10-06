using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorApp.ViewModels.Categories;
using razorApp.ViewModels.Course;
using razorApp.ViewModels.Teacher;

namespace razorApp.Pages.Views.Courses
{
    public class Create : PageModel
    {
        private readonly ILogger<Create> _logger;
        private readonly IConfiguration _config;
        [BindProperty]
        public CreateCourseViewModel Course { get; set; } = new CreateCourseViewModel();
        public List<GetCategoryViewModel>? Categories { get; set; } = new List<GetCategoryViewModel>();

        public Create(ILogger<Create> logger, IConfiguration config)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            using var http = new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses";
            var response = await http.PostAsJsonAsync(url, Course);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Något gick fel vi Kunde inte spara kursen!");
            }

            return RedirectToPage("Create");

        }

        public async Task OnGetAsync()
        {
            try
            {
                var baseUrl = _config.GetValue<string>("baseUrl");
                var url = $"{baseUrl}/categories/list";
                using var http = new HttpClient();
                Categories = await http.GetFromJsonAsync<List<GetCategoryViewModel>>(url);
                if (Categories is null)
                {
                    _logger.LogError("Kategori listan är tom!");
                    StatusCode(500, "Något gick fel! Vi Kunde inte hämta kategorierna..");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Något gick snett! Vi kunde inte Lista kategorierna..");
                StatusCode(500, ex.Message);
            }

        }

    }
}
