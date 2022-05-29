using Microsoft.AspNetCore.Mvc;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Controllers
{
  [ApiController]
    [Route("api/v1/categories")]
    public class Categorycontroller : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult<List<CategoryViewModel>>>ListALLCategories(){
            return Ok();
        }
     
        [HttpPost()]
        public async Task<ActionResult<PostCategoryViewModel>> AddCategory()
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