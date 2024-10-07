using EXamination.Core.Models;
using EXamination.Core.RepositoriesInterFaces;
using EXamination.Core.ServicesInterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Service.Services
{
    public class StudentExamService:IStudentExamService
    {
        private readonly IStudentExamRepository _studentExamRepository;
        public StudentExamService(IStudentExamRepository studentExamRepository)
        {
            _studentExamRepository = studentExamRepository;
        }

        public async Task<List<Exam>> GetAssignedExamsAsync(int studentId)
        {
            var exams = await _studentExamRepository.GetExamsByStudentIdAsync(studentId);

            return exams;
        }
    }
}
