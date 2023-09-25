using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MvcApp.ViewModels;

namespace MvcApp.Models
{
    public class AuthServiceModel
    {
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _config;
        public AuthServiceModel(IConfiguration config)
        {
            _config = config;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        }
        public async Task<RegisterViewModel> RegisterUser(RegisterViewModel model)
        {

            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/Auth/register";
            using var http = new HttpClient();
            var response = await http.PostAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Något gick fel, vi kunde inte registrera användaren!");

            }
            return model;
        }
    }
}