using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WestcoastEducation_API.Repositories;

namespace WestcoastEducation_API.Controllers
{
    [ApiController]
    [Route("api/Students")]
    public class StudentController : ControllerBase
    {
    private readonly StudentRepository _repo;
    public StudentController(StudentRepository repo)
    {
      _repo = repo;

    }

    public async Task<ActionResult>ListStudents(){
           return Ok(200);
       }


    }
}