using Microsoft.AspNetCore.Mvc;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.Repositories;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Controllers
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriesRepository _categoryRepo;
        public CategoryController(ICategoriesRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;

        }

        [HttpGet("list")]
        public async Task<ActionResult<List<CategoryViewModel>>> ListALLCategories()
        {
            try
            {

                var list = await _categoryRepo.ListAllCategoriesAsync();

                if (list is not null) { return Ok(list); }

                return NotFound("Det finns inga kategorier, lägg till ny kategori!.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost()]
        public async Task<ActionResult> AddCategory(PostCategoryViewModel model)
        {
            try
            {
                await _categoryRepo.AddCategoryAsync(model);
                if (await _categoryRepo.SaveAllAsync())
                {

                    return StatusCode(201);
                }

                return StatusCode(500, "Något gick fel när vi skulle spara kategorin!");

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            };
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

                return StatusCode(500, ex.Message);
            }

        }
    }
}