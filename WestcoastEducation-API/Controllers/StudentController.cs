using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;
using WestcoastEducation_API.Repositories;
using WestcoastEducation_API.ViewModels.Students;

namespace WestcoastEducation_API.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentController : ControllerBase
    {

  
    private readonly IStudentRepository _repo;

    public StudentController(IStudentRepository repo )
    {
      _repo = repo;
      
    }
    [HttpGet("list")]
    public async Task<ActionResult> ListStudents(){
      return Ok(await _repo.ListStudentsAsync());
    }
   [HttpGet("{id}")]
    public async Task<ActionResult<StudentViewModel>>GetStudent(int id)
    {
      
       try
       {
         
        var model = await _repo.GetStudentAsync(id);
        if(model is not null)
        {
          return Ok(model);
        }
        return BadRequest($"Vi kunde inte hitta elev med id:{id}!");
         
       }
       catch (Exception ex)
       {
         
      return StatusCode(500, ex.Message);
       }
    }

     [HttpGet("byemail/{email}")]
    public async Task<ActionResult<StudentViewModel>>GetStudentByEmail(string email)
    {
      
       try
       {
         
        var model = await _repo.GetStudentByEmailAsync(email);
        if(model is not null)
        {
          return Ok(model);
        }
        return BadRequest($"Vi kunde inte hitta någon elev med mejleadress:{email}!");
         
       }
       catch (Exception ex)
       {
         
      return StatusCode(500, ex.Message);
       }
    }
    [HttpPost()]
    public async Task<ActionResult>AddStudents(PostStudentViewModel model)
    {
      try
      {
          await _repo.AddStudentAsync(model);
        
          if(  await _repo.SaveAllAsync()){
          return StatusCode(201);
          }
          return StatusCode (500, "Det gick inte att spara elevens information!" );
         
        
      }
      catch (Exception ex)
      {
        
       return StatusCode(500, ex.Message);
      }
        
       }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(int id, PostStudentViewModel model)
    {

  try
  {
    await _repo.UpdateStudentAsync(id, model);
    if(await _repo.SaveAllAsync()){
      return NoContent();
    }
    return StatusCode(500, " Ett fel inträgffade när elevens information skulle ändras..!" );
  }
  catch (Exception ex)
  {
    
    return StatusCode(500, ex.Message);
  }

}

    [HttpDelete("{id}")]
     public async Task<ActionResult> DeleteStudent(int id)
     {
  await _repo.DeleteStudentAsync(id);
  if (await _repo.SaveAllAsync())
  {
   return NoContent();
  }
  return StatusCode(500, ("Nogåt gick fel när vi skulle radera Elevens informaion..!"));
}
    }
}