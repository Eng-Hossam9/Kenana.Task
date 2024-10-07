using EXamination.Core.Models;
using EXamination.Core.RepositoriesInterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EXamination.Core.RepositoriesInterFaces
{
    public interface IExamRepository: IGenaricRepository<Exam,int>
    {
       Task<int> assignExamAsync(List<Student> entities,int Examid);
    }
}
