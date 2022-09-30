using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.Repositories;
using WestcoastEducation_API.ViewModels;
using WestcoastEducation_API.ViewModels.Category;

namespace WestcoastEducation_API.Controllers
{
  [ApiController]
  [Route("api/v1/Courses")]
  public class CourseController : ControllerBase
  {

    private readonly ICourseRepository _courseRepo;
    private readonly IMapper _mapper;
    private readonly CourseContext _context;

    public CourseController(ICourseRepository courseRepo, IMapper mapper, CourseContext context)
    {
      _context = context;
      _mapper = mapper;
      _courseRepo = courseRepo;


    }

    [HttpGet("list")]
    public async Task<ActionResult<List<CourseByCategoryViewModel>>> ListCourses()
    {

      var courseList = await _courseRepo.ListAllCoursesAsync();
      if (courseList is null)
      {
        return NotFound("Kurs listan är tom läg till en ny kurs i listan och försök en gång till!.... ");
      }
      return Ok(courseList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseViewModel>> GetCoursById(int id)
    {
      try
      {
        var response = await _courseRepo.GetCourseAsync(id);

        if (response is null)
        {
          return NotFound($"Vi kunde inte hittat någon kurs med id {id}!");
        }

        return Ok(response);
      }
      catch (Exception ex)
      {

        return StatusCode(500, ex.Message);
      }

    }
    [HttpGet("ByCat/{subject}")]

    public async Task<ActionResult<List<CourseByCategoryViewModel>>> ListCoursesByCategory(string subject)
    {
      try
      {

        var list = await _courseRepo.ListCoursesByCategoryAsync(subject);
        return Ok(list);
      }
      catch (Exception ex)
      {

        return StatusCode(500, ex.Message);
      }
    }
    [HttpGet("category/{id}")]

    public async Task<ActionResult<List<CourseByCategoryViewModel>>> ListCoursesByCategoryId(int id)
    {
      try
      {

        var list = await _courseRepo.ListCoursesByCategoryIdAsync(id);
        return Ok(list);
      }
      catch (Exception ex)
      {

        return StatusCode(500, ex.Message);
      }
    }

    [HttpPost()]
    public async Task<ActionResult> AddCourse(PostCourseViewModel model)
    {
      try
      {
        if (await _courseRepo.GetCourseAsync(model.CourseId) is not null)
        { return BadRequest($"Kursen med nummer {model.CourseId} finns redan i systemet"); }

        await _courseRepo.AddCourseAsync(model);

        if (await _courseRepo.SaveAllAsync())
        {

          return StatusCode(201);
        }
        else { return StatusCode(500, "Det gick inte att spara kursen"); }

      }
      catch (Exception ex)
      {

        return StatusCode(500, ex.Message);
      }

    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCourse(int id, PutCourseViewModel model)
    {
      try
      {
        await _courseRepo.UpdateCourseAsync(id, model);
        if (await _courseRepo.SaveAllAsync())
        {
          return NoContent();
        }
        return StatusCode(500, "Ett fel inträffade när kursen sklulle ändras!");
      }
      catch (Exception ex)
      {

        return StatusCode(500, ex.Message);
      }


    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteCourse(int id)
    {
      await _courseRepo.DeleteCourseAsync(id);

      if (await _courseRepo.SaveAllAsync())
      {
        return NoContent();// StatusCode 204
      }
      return StatusCode(500, "Hoppsan något gick fel!..");
    }
    [HttpPatch("AddToStudent{studentEmail}")]
    public async Task<ActionResult> AddStudentToCourse(int courseId, string studentEmail)
    {
      try
      {

        await _courseRepo.AddStudentToCourseAsync(courseId, studentEmail);

        if (await _courseRepo.SaveAllAsync()) { return NoContent(); }
        return StatusCode(500, "Ett fel inträffade när vi sklulle lägga sutdneten till kursen!");
      }
      catch (Exception ex)
      {

        return StatusCode(500, ex.Message);
      }


    }
     [HttpGet("fullList")]
    public async Task<ActionResult<CourseViewModel>> ListCoursesFull()
    {
      try
      {

        var courses = await _courseRepo.ListCoursesFullAsync();
        if (courses is null)
        {
          return NotFound("Kurs listan är tom läg till en ny kurs i lista och försök en gång till!.... ");
        }
        return Ok(courses);
      }
      catch (Exception ex)
      {

        return StatusCode(500, ex.Message);

      }
    }

  }
}
