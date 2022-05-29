using Microsoft.AspNetCore.Mvc;
using WestcoastEducation_API.Models;

namespace WestcoastEducation_API.Controllers
{
  [ApiController]
    [Route("api/v1/categories")]
    public class Categorycontroller : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult<List<Category>>>ListALLCategories(){
            return Ok();
        }
     
        [HttpPost()]
        public async Task<ActionResult> AddCategory()
        {
           return StatusCode(201);
        }

        [HttpDelete()]
        public async Task<ActionResult> DeleteCategory()
        {
          return NoContent();
        }



    }
}