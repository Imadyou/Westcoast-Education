using Microsoft.AspNetCore.Mvc;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.Repositories;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Controllers
{
  [ApiController]
    [Route("api/v1/categories")]
    public class Categorycontroller : ControllerBase
    {
    private readonly ICategoriesRepository _categoryRepo;
    public Categorycontroller(ICategoriesRepository categoryRepo)
    {
      _categoryRepo = categoryRepo;

    }

    [HttpGet("list")]
        public async Task<ActionResult<List<CategoryViewModel>>>ListALLCategories(){
            
          var list= await _categoryRepo.ListAllCategoriesAsync();
          return Ok(list);
           
        }
        [HttpGet("categoris/courses")]
        public async Task<ActionResult>ListCategoriesWithCoursesViewModel(){
            var list= await _categoryRepo.ListCategoriesAndCourses();
            return Ok(list);
        }
        [HttpGet("{id}/courses")]
        public async Task<ActionResult>ListCategoryCourses(int id)
        {
          var list=await _categoryRepo.ListCategoryCourses(id);
          return Ok(list);

        }
     
        [HttpPost()]
        public async Task<ActionResult> AddCategory(PostCategoryViewModel model)
        {
            try
            {
             await _categoryRepo.AddCategoryAsync(model);
            if(await _categoryRepo.SaveAllAsync()){

           return StatusCode(201);
            }
            else
            {
           return StatusCode(500, "Det gicka fel när vi skulle spara kategorin!");
            }

 
            }
            catch (Exception)
            {
                
               throw new Exception ("Det gicka fel när vi skulle spara kategorin!");
            }
;          
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryRepo.DeleteCategoryAsync(id);
                if (await _categoryRepo.SaveAllAsync())
                {
                    return NoContent();
                }
                return StatusCode(500, $"Det gick inte att ta bort kategori med id: {id} !");
            }
            catch (Exception ex)
            {
                
               return StatusCode (500, ex.Message);
            }
       
        }
    }
}