using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

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
    
    
    
    
  }
}