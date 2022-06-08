using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcApp.ViewModels.Categories;

namespace MvcApp.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
    private readonly IConfiguration _config;
    public CategoriesController(IConfiguration config)
    {
      _config = config;
    }

    public async Task<IActionResult> Index()
        {  
            var options =new JsonSerializerOptions{PropertyNameCaseInsensitive=true};
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Categories/list";
            using var http=new HttpClient();
            var response = await http.GetAsync(url);
            if(!response.IsSuccessStatusCode)
            {
              Console.WriteLine("kunde inte hämta paketet från API application");
            }
            var result =await response.Content.ReadAsStringAsync();
            var categories= JsonSerializer.Deserialize<List<CategoryViewModel>>(result,options);      
            return View();
        }
    
    }
}