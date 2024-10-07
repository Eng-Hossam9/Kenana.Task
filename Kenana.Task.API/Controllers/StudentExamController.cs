using EXamination.Core.Models;
using EXamination.Core.ServicesInterFaces;
using Kenana.Task.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kenana.Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamController : ControllerBase
    {
        private readonly IStudentExamService _studentExamService;

        public StudentExamController(IStudentExamService studentexamService)
        {
            _studentExamService = studentexamService;
        }

        [HttpGet("Exams/{studentId}")]
        public async Task<IActionResult> GetStudentExams(int studentId)
        {
            try
            {
                var exams = await _studentExamService.GetAssignedExamsAsync(studentId);

                if (exams == null || exams.Count == 0)
                {
                    return NotFound($"No exams found for student with ID {studentId}");
                }
                var studentExamDTo = new List<StudentExamDTO>();
                foreach (var item in exams)
                {
                    var studentExam = new StudentExamDTO()
                    {
                        ExamName = item.Name,
                        DateOfExam = item.DateOfExam

                    };
                    studentExamDTo.Add(studentExam);

                }


                return Ok(studentExamDTo);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
