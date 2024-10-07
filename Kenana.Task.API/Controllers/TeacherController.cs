using EXamination.Core.Data;
using EXamination.Core.RepositoriesInterFaces;
using EXamination.Core.ServicesInterFaces;
using EXamination.Repository.Repositories;
using EXamination.Service.Services;
using Kenana.Task.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kenana.ExamTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _TeacherService;
        private readonly ExaminationContext _Context;

        public TeacherController(ITeacherService teacherService, ExaminationContext context)
        {
            _TeacherService = teacherService;
            _Context = context;
        }


       


            [HttpGet]
        public async Task<IActionResult> GetAllTeacher()
        {
                var teachers = await _TeacherService.GetAllTeachers();
                return Ok(teachers);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherByid(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Teacher = await _TeacherService.GetByIdTeacher(id);

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
