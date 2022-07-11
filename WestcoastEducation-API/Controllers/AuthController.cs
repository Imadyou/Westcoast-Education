using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels.AuthViewModel;

namespace Step03_ASP.NET_Identity.ViewModels
{
  [ApiController]
  [Route("api/v1/auth")]
 public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
    private readonly CourseContext _context;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, CourseContext context)
        {
             _context = context;
            _userManager = userManager;
            _signInManager= signInManager;
        }
[HttpPost("register")]
    public async Task<ActionResult<RegisterViewModel>> RegisterUser(RegisterViewModel model)
    {
      var user = new IdentityUser
      {
        UserName=model.Email,
        Email = model.Email!,
       
      };

      var result = await _userManager.CreateAsync(user, model.Password);
      if(!result.Succeeded){
        throw new Exception ("Gisk inte att registrea användaren");
      }
   
        return StatusCode(201, user);
   }
   
       
    }
}