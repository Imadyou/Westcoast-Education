using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcApp.Models;
using MvcApp.ViewModels;

namespace MvcApp.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {


        private readonly AuthServiceModel _service;
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;

            _service = new AuthServiceModel(_config);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RegisterViewModel model)
        {
            try
            {

                await _service.RegisterUser(model);
                return View(model);

            }
            catch (Exception)
            {

                return StatusCode(500, "Något gick fel! Vi kunde inte registrera användaren! Kontrollera din informationen och försök igen.");
            }
        }
    }
}