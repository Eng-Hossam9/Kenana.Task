using EXamination.Core.Data;
using EXamination.Core.ServicesInterFaces;
using EXamination.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kenana.ExamTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _StudentService;
        private readonly ExaminationContext _Context;

        public StudentController(IStudentService StudentService, ExaminationContext context)
        {
            _StudentService = StudentService;
            _Context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var teachers = await _StudentService.GetAllStudent();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByid(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Teacher = await _StudentService.GetStudentbyid(id);

                if (Teacher == null)
                {
                    return NotFound($"No Teacher found  with ID {id}");
                }


                return Ok(Teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    
    }
}
