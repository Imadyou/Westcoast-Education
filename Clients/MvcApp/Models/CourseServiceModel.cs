using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace MvcApp.ViewModels.Courses
{
  public class CourseServiceModel
  {
    private readonly IConfiguration _config;
    private readonly JsonSerializerOptions _options;
    public CourseServiceModel(IConfiguration config)
    {
      _config = config;
      _options =new JsonSerializerOptions{PropertyNameCaseInsensitive=true};
    }
    
    public async Task<List<CourseByCategoryViewModel>>ListCoursesByCatId(int id){
          var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/category/{id}";
            using var http=new HttpClient();
            var response = await http.GetAsync(url);
            if(!response.IsSuccessStatusCode)
            {
              throw new Exception("kunde inte hämta paketet från API application");
            }
            var courses =await response.Content.ReadFromJsonAsync<List<CourseByCategoryViewModel>>();
            // var result =await response.Content.ReadAsStringAsync();
            // var courses= JsonSerializer.Deserialize<List<CourseByCategoryViewModel>>(result,_options);
            return courses?? new List<CourseByCategoryViewModel>();

    }

    public async Task<CourseViewModel>GetCourseById(int id)
    {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/{id}";
            using var http=new HttpClient();
            var response = await http.GetAsync(url);
            if(!response.IsSuccessStatusCode)
            {
              throw new Exception("Det gick inte att hitta kursen!");
            }
            var course= await response.Content.ReadFromJsonAsync<CourseViewModel>();
            // var result =await response.Content.ReadAsStringAsync();
            // var course= JsonSerializer.Deserialize<CourseViewModel>(result,_options);
            return course??=new CourseViewModel();
    }

  }
}