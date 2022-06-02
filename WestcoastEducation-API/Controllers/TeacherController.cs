using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.ViewModels.Teachers;

namespace WestcoastEducation_API.Controllers
{
  [ApiController]
  [Route("api/v1/Teachers")]
  public class TeacherController : ControllerBase
  {
    private readonly ITeachersRepository _repo;
    public TeacherController(ITeachersRepository repo)
    {
      _repo = repo;
    }
     [HttpGet()]
    public async Task<ActionResult> ListTeachers(){
      return Ok(await _repo.ListTeachersAsync());
    }


    [HttpPost()]
    public async Task<ActionResult>AddSTeacher(PostTeacherViewModel model){
      try
      {
          await _repo.AddTeacherAsync(model);
        
          if(  await _repo.SaveAllAsync()){
          return StatusCode(201);
          }
          return StatusCode (500, "Det gick inte att spara läraren ..!" );
         
        
      }
      catch (Exception ex)
      {
        
       return StatusCode(500, ex.Message);
      }
        
       }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTeacher(int id, TeacherViewModel model){

  try
  {
    await _repo.UpdateTeacherAsync(id,model);
    if(await _repo.SaveAllAsync()){
      return NoContent();
    }
    return StatusCode(500, " Ett fel inträgffade när lärarens information skulle ändras..!" );
  }
  catch (Exception ex)
  {
    
    return StatusCode(500, ex.Message);
  }

}

    [HttpDelete("{id}")]
     public async Task<ActionResult> DeleteTeacher(int id){
  await _repo.DeleteTeacherAsync(id);
  if (await _repo.SaveAllAsync())
  {
   return NoContent();
  }
  return StatusCode(500, ("Nogåt gick fel när vi skulle radera lärarens informaion..!"));
}
  }
}