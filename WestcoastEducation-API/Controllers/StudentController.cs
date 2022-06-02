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
    [HttpGet()]
    public async Task<ActionResult> ListStudents(){
      return Ok(await _repo.ListStudentsAsync());
    }


    [HttpPost()]
    public async Task<ActionResult>AddStudents(PostStudentViewModel model){
      try
      {
          await _repo.AddStudentAsync(model);
        
          if(  await _repo.SaveAllAsync()){
          return StatusCode(201);
          }
          return StatusCode (500, "Det gick inte att spara studenten..!" );
         
        
      }
      catch (Exception ex)
      {
        
       return StatusCode(500, ex.Message);
      }
        
       }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(int id, StudentViewModel model){

  try
  {
    await _repo.UpdateStudentAsync(id,model);
    if(await _repo.SaveAllAsync()){
      return NoContent();
    }
    return StatusCode(500, " Ett fel inträgffade när studentens information skulle ändras..!" );
  }
  catch (Exception ex)
  {
    
    return StatusCode(500, ex.Message);
  }

}

    [HttpDelete("{id}")]
     public async Task<ActionResult> DeleteStudent(int id){
  await _repo.DeleteStudentAsync(id);
  if (await _repo.SaveAllAsync())
  {
   return NoContent();
  }
  return StatusCode(500, ("Nogåt gick fel när vi skulle radera studnetens informaion..!"));
}
    }
}