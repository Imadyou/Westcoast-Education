using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MvcApp.ViewModels.Categories;

namespace MvcApp.Models
{
  public class CategoryServiceModel
  {
     private readonly IConfiguration _config;
    private readonly JsonSerializerOptions _options;
    public CategoryServiceModel(IConfiguration config)
    {
      _config = config;
      _options =new JsonSerializerOptions{PropertyNameCaseInsensitive=true};
    }

    public async Task<List<CategoryViewModel>>ListCategories(){
          var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Categories/list";
            using var http=new HttpClient();
            var response = await http.GetAsync(url);
            if(!response.IsSuccessStatusCode)
            {
              throw new Exception("kunde inte hämta paketet från API application");
            }
            var courses =await response.Content.ReadFromJsonAsync<List<CategoryViewModel>>();
    
            return courses?? new List<CategoryViewModel>();

    }
    
    
    
    
  }
}