using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.Repositories;
using WestcoastEducation_API.ViewModels;

namespace WestcoastEducation_API.Controllers
{
  [ApiController]
    [Route("api/v1/Courses")]
    public class CourseController : ControllerBase
    {
   
    private readonly ICourseRepository _courseRepo;
    private readonly IMapper _mapper;

    public CourseController( ICourseRepository courseRepo, IMapper mapper )
    {
      _mapper = mapper;
      _courseRepo = courseRepo;
     
    } 

    [HttpGet()]
    public async Task <ActionResult<List<CourseViewModel>>> ListCourses()
    {
    
      var courseList=await _courseRepo.ListAllCoursesAsync();
        
      return Ok(courseList);
    }

    [HttpGet("{id}")]
    public async Task <ActionResult<CourseViewModel>> GetCoursById(int id)
    {
      try
      {
          var response= await _courseRepo.GetCourseAsync(id);
      
      if(response is null){
        return NotFound($"Vi kunde inte hittat någon kurs med id {id}!");
      }
     
      return Ok(response);
      }
      catch (Exception ex )
      {
        
        return StatusCode(500, ex.Message);
      }
   
    }
    

    [HttpPost()]
    public async Task <ActionResult> AddCourse(PostCourseViewModel model)
    {
            try
            {
                if (await _courseRepo.GetCourseAsync(model.CourseId)is not null)
                { return BadRequest($"Kursen med nummer {model.CourseId} finns redan i systemet"); }

                await _courseRepo.AddCourseAsync(model);

                    if (await _courseRepo.SaveAllAsync())
                {
                   
                    return StatusCode(201);
                }
                else{  return StatusCode(500, "Det gick inte att spara kursen");}
              
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
         

      
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCourse(int id, PostCourseViewModel model)
    {
     try
     {
       await _courseRepo.UpdateCourse(id,model);
       if(await _courseRepo.SaveAllAsync()){
         return NoContent();
       }
       return StatusCode(500, "Ett fel inträffade när kursen sklulle ändras!");
     }
     catch (Exception ex)
     {
   
      return StatusCode(500, ex.Message);
     }


    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCourse(int id){
        await _courseRepo.DeleteCourse(id);
      
      if(await _courseRepo.SaveAllAsync()){
        return NoContent();// StatusCode 204
        }
        return StatusCode(500, "Hoppsan något gick fel!..");
    }
  }
    
}