using Microsoft.AspNetCore.Mvc;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.Repositories;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Controllers
{
  [ApiController]
    [Route("api/v1/categories")]
    public class Categorycontroller : ControllerBase
    {
    private readonly CategoriesRepository _categoryRepo;
    public Categorycontroller(CategoriesRepository categoryRepo)
    {
      _categoryRepo = categoryRepo;

    }

    [HttpGet()]
        public async Task<ActionResult<List<CategoryViewModel>>>ListALLCategories(){
            
          return await _categoryRepo.ListAllCategoriesAsync();
           
        }
     
        [HttpPost()]
        public async Task<ActionResult> AddCategory(PostCategoryViewModel model)
        {
            await _categoryRepo.AddCategoryAsync(model);
            if(await _categoryRepo.SaveAllAsync()){

           return StatusCode(201);
            }
            return StatusCode(500, "Det gicka fel när vi skulle spara kategori !");
        }

        // [HttpDelete()]
        // public async Task<ActionResult> DeleteCategory()
        // {
        //   return NoContent();
        // }


    }
}