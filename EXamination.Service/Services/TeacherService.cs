using EXamination.Core.Models;
using EXamination.Core.RepositoriesInterFaces;
using EXamination.Core.ServicesInterFaces;
using EXamination.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Service.Services
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _TeacherRepository;

        public TeacherService(ITeacherRepository TeacherRepository)
        {
            _TeacherRepository = TeacherRepository;
        }
        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
          var Teachers = await  _TeacherRepository.GetAllAsync();

            return Teachers;

        }

        public async Task<Teacher> GetByIdTeacher(int teacherId)
        {
            var teacher=await _TeacherRepository.GetByIdAsync(teacherId);
            return teacher;
            
        }
    }
}
