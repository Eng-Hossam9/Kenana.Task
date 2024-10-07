using EXamination.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Core.ServicesInterFaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudent();
        Task<Student> GetStudentbyid(int Studentid);
    }
}
