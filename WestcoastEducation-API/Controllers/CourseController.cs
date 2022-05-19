using Microsoft.AspNetCore.Mvc;

namespace WestcoastEducation_API.Controllers
{
  [ApiController]
    [Route("api/v1/Courses")]
    public class CourseController : ControllerBase
    {
    [HttpGet()]
    public ActionResult ListCourses()
    {
      return StatusCode(200, "{'message': 'Det funkar'}");
    }

    [HttpGet("{id}")]
    public ActionResult GetCoursById(int id)
    {
      return StatusCode(200, "{'message': 'Det funkar också bra!..'}");
    }

    [HttpPost()]
    public ActionResult AddCourse(){
        return StatusCode(201,"{'message': 'Det funkar också bra!..'}" );
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCourse(int id){
        return NoContent();// StatusCode 204
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCourse(int id){
        return NoContent();// StatusCode 204
    }
  }
    
}