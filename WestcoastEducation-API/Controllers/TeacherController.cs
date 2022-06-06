using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Models;
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
    [HttpGet("list")]
    public async Task<ActionResult> ListTeachers()
    {
      try{  var list=await _repo.ListTeachersAsync();

      if(list is not null)
      {
      return Ok(list);

      }
       return StatusCode(500, "Något gick fel när vi skulle hämat LärarensLista ..!");
      }
      catch(Exception ex)
      {
        return StatusCode(500,ex.Message);
      }
    }

    [HttpPost()]
    public async Task<ActionResult> AddSTeacher(PostTeacherViewModel model)
    {
      try
      {
        await _repo.AddTeacherAsync(model);

        if (await _repo.SaveAllAsync())
        {
          return StatusCode(201);
        }
        return StatusCode(500, "Det gick inte att spara läraren ..!");


      }
      catch (Exception ex)
      {

        return StatusCode(500, ex.Message);
      }

    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTeacher(int id, PostTeacherViewModel model)
    {

      try
      {
        await _repo.UpdateTeacherAsync(id, model);
        if (await _repo.SaveAllAsync())
        {
          return NoContent();
        }
        return StatusCode(500, " Ett fel inträgffade när lärarens information skulle ändras..!");
      }
      catch (Exception ex)
      {

        return StatusCode(500, ex.Message);
      }

    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTeacherById(int id)
    {
      await _repo.DeleteTeacherAsync(id);
      if (await _repo.SaveAllAsync())
      {
        return NoContent();
      }
      return StatusCode(500, ("Nogåt gick fel när vi skulle radera lärarens informaion..!"));
    }

   [HttpDelete("byemail/{email}")]
    public async Task<ActionResult> DeleteTeacherByEmail(string email)
    {
      await _repo.DeleteTeacherByEmailAsync(email);
      if (await _repo.SaveAllAsync())
      {
        return NoContent();
      }
      return StatusCode(500, ("Nogåt gick fel när vi skulle radera lärarens informaion..!"));
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherViewModel>> GetTeacherById(int id)
    {
      try
      {
        var model = await _repo.GetTeacherAsync(id);
        if (model is not null)
        {
          return Ok(model);
        }
        return BadRequest( $"Läraren med Id{id} kunde inte hittas!");

      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
      [HttpGet("byemail/{email}")]
    public async Task<ActionResult<TeacherViewModel>> GetTeacherByEmail(string email)
    {
      try
      {
        var model = await _repo.GetTeacherByEmail(email);
        if (model is not null)
        {
          return Ok(model);
        }
        return BadRequest( $"Läraren som har email: {email} kunde inte hittas!");

      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}