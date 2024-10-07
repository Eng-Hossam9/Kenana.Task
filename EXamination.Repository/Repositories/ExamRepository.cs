using EXamination.Core.Data;
using EXamination.Core.Models;
using EXamination.Core.RepositoriesInterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Repository.Repositories
{
    public class ExamRepository : GenaricRepository<Exam, int>,IExamRepository
    {
        private readonly ExaminationContext _context;

        public ExamRepository(ExaminationContext context):base(context)
        {
            _context = context;
        }

      

        public async Task<int> assignExamAsync(List<Student> entities, int Examid)
        {
            var Exam = await GetByIdAsync(Examid);
            var studentExam = new List<Core.Models.StudentExam>();

            foreach (var item in entities)
            {
                studentExam.Add(new Core.Models.StudentExam
                {
                    ExamId = Exam.Id,
                    StudentId = item.Id

                });
            }
            await _context.StudentExams.AddRangeAsync(studentExam);
            return await _context.SaveChangesAsync();
        }
    }
}




