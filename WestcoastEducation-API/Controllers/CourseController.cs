using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.ViewModels;

namespace WestcoastEducation_API.Controllers
{
  [ApiController]
    [Route("api/v1/Courses")]
    public class CourseController : ControllerBase
    {
    private readonly CourseContext _context;

    public CourseController(CourseContext context)
    {
      _context = context;
    } 

    [HttpGet()]
    public async Task <ActionResult<List<CourseViewModel>>> ListCourses()
    {
      var response= await _context.Courses.ToListAsync();
      var courseList=new List<CourseViewModel>();
      foreach(var course in response){
        courseList.Add( new CourseViewModel{
          Id = course.Id, 
          Title=course.Title,
          CourseLength=$"{course.Days} days, {course.Hours} video houres. ",
           Description=course.Description, 
          Details=course.Details
        });
        
      }
      return Ok(courseList);
    }

    [HttpGet("{id}")]
    public async Task <ActionResult<Course>> GetCoursById(int id)
    {
      var response = await _context.Courses.FindAsync(id);
      if(response is null){
        return NotFound($"Vi kunde inte hittat någon kurs med id {id}!");
      }


      return Ok( response);
    }
    

    [HttpPost()]
    public async Task <ActionResult<PostCourseViewModel>> AddCourse(PostCourseViewModel course)
    { 
      var courseToAdd = new Course{
        Id=course.CourseId,
        Title=course.CourseTitle,
        Days=course.NumberOfDays,
        Hours=course.VideoHours,
        Description=course.Description,
        Details=course.Details
      };
       await _context.Courses.AddAsync(courseToAdd);
       await _context.SaveChangesAsync();
        return StatusCode(201,courseToAdd);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Course>> UpdateCourse(int id, Course model)
    {
      var response = await _context.Courses.FindAsync(id);
        if(response is null){
        return NotFound($"Vi kunde inte hitta någon kurs med id {id}!");
      }
      response.Title=model.Title;
      response.Days=model.Days;
      response.Hours=model.Hours;
      // response.Category=model.Category;
      response.Description=model.Description;
      response.Details=model.Details;

      _context.Courses.Update(response);
      await _context.SaveChangesAsync();

        return NoContent();// StatusCode 204
    }

    [HttpDelete("{id}")]
    public async Task< ActionResult> DeleteCourse(int id){
      var response = await _context.Courses.FindAsync(id);
      if(response is null){
        return NotFound($"Vi kunde inte hitta någon kurs med id {id} som skulle tas bort.");
      }
      _context.Courses.Remove(response);
      await _context.SaveChangesAsync();
        return NoContent();// StatusCode 204
    }
  }
    
}