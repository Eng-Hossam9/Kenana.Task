using EXamination.Core.Data;
using EXamination.Core.Models;
using EXamination.Core.RepositoriesInterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Repository.Repositories
{
    public class StudentRepository : GenaricRepository<Student, int>,IStudentRepository
    {
        public StudentRepository(ExaminationContext context) : base(context)
        {
        }
    }
}
