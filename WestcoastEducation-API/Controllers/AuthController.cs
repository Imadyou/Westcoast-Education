using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Models;

namespace Step03_ASP.NET_Identity.ViewModels
{
  [ApiController]
  [Route("api/v1/auth")]
 public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
    private readonly CourseContext _context;
        public AuthController(UserManager<IdentityUser> userManager, CourseContext context)
        {
             _context = context;
            _userManager = userManager;
        }
[HttpPost("register")]
    public async Task<ActionResult<RegisterViewModel>> RegisterUser(RegisterViewModel model)
    {
      var user = new IdentityUser
      {
        Email = model.Email!.ToLower(),
        PasswordHash = model.Password!.ToLower()
      };

      var result = await _userManager.CreateAsync(user, model.Password);

     
        // var userData = new RegisterViewModel
        // {
        //   Email = user.Email,
        //   Password= user.PasswordHash,
      
        // };
       await _context.SaveChangesAsync();
        return StatusCode(201, user);
   }
   
       
    }
}