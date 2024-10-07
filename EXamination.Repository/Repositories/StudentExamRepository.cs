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
    public class StudentExamRepository : IStudentExamRepository
    {
        private readonly ExaminationContext _context;

        public StudentExamRepository(ExaminationContext context)
        {
            _context = context;
        }
        public async Task<List<Exam>> GetExamsByStudentIdAsync(int studentId)=> await _context.StudentExams
                                                                                      .Where(se => se.StudentId == studentId)
                                                                                      .Include(se => se.Exam)
                                                                                      .Select(se => se.Exam)
                                                                                      .ToListAsync();
    }
        
    }

