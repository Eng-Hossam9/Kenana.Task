using Examination.Kenan.DTO;
using EXamination.Core.Data;
using EXamination.Core.Models;
using EXamination.Core.RepositoriesInterFaces;
using EXamination.Repository.Repositories;
using Kenana.Task.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kenana.Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        private readonly IExamRepository _examRepository;
        private readonly ExaminationContext _Context;

        public ExamController(IExamRepository examRepository, ExaminationContext context)
        {
            _examRepository = examRepository;
            _Context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExams()
        {
            var exams = await _examRepository.GetAllAsync();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            try
            {

                var exam = await _examRepository.GetByIdAsync(id);
                if (exam == null)
                {
                    return NotFound($"this {id}: NotFound");
                }
                return Ok(exam);
            }
            catch (Exception ex) { 
                    
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddExam")]
        public async Task<IActionResult> AddExam([FromBody] AddExamDTO exam)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Data Not Valid valid");
                }
                var ExamDB = new Exam()
                {
                    DateOfExam = exam.DateOfExam,
                    Name = exam.Name,
                    TeacherId = exam.TeacherId
                };
                var result = await _examRepository.AddAsync(ExamDB);
                if (result > 0)
                {
                    return Ok("Success");
                }
                return BadRequest("valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

           
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, [FromBody] ExamDTO examDTO)
        {
            try
            {
                if (id != examDTO.Id || !ModelState.IsValid)
                {
                    return BadRequest("Id NOt Equal Exam ID");
                }
                var Exam = new Exam()
                {
                    Id=examDTO.Id.Value,
                    Name = examDTO.Name,
                    DateOfExam = examDTO.DateOfExam,
                    TeacherId = examDTO.TeacherId,
                };

                var result = await _examRepository.Update(Exam);
                if (result > 0)
                {
                    return Ok("Success");
                }

                return NotFound($"this {id}: NotFound");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            try
            {
                var result = await _examRepository.Delete(id);

                if (result > 0)
                {
                    return Ok("Deleted Successfuly");
                }

                return NotFound($"this {id}: NotFound");
            }
            catch (Exception ex) { 
                
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("assignExam")]
        public async Task<IActionResult> AssignExam(List<int> studentsID, int id)
        {
            try
            {
                var students = new List<Student>();
                foreach (var stud in studentsID)
                {
                    var student = await _Context.Students.FindAsync(stud);

                    if (student != null)
                    {
                        students.Add(student);
                    }
                }
                var result = await _examRepository.assignExamAsync(students, id);
                if (result > 0)
                {
                    
                    return Ok("Assigned");
                }
                return BadRequest("Faild");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
