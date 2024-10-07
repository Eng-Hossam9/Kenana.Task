using EXamination.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Core.ServicesInterFaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task<Teacher> GetByIdTeacher(int teacherId);


    }
}
