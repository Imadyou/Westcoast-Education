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
    
    public async Task<List<CourseByCategoryViewModel>>ListCourses(){
          var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Courses/list";
            using var http=new HttpClient();
            var response = await http.GetAsync(url);
            if(!response.IsSuccessStatusCode)
            {
              throw new Exception("kunde inte hämta paketet från API application");
            }
            var result =await response.Content.ReadAsStringAsync();
            var courses= JsonSerializer.Deserialize<List<CourseByCategoryViewModel>>(result,_options);
            return courses?? new List<CourseByCategoryViewModel>();

    }

  }
}