using EXamination.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Core.RepositoriesInterFaces
{
    public interface IStudentExamRepository
    {
        Task<List<Exam>> GetExamsByStudentIdAsync(int studentId);

    }
}
