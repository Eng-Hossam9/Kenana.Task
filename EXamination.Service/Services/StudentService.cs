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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _StudentRepository;

        public StudentService(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }
        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            var students=await _StudentRepository.GetAllAsync();

            return students;
        }

        public async Task<Student> GetStudentbyid(int Studentid)
        {
            var student = await _StudentRepository.GetByIdAsync(Studentid);
            return student;
        }
    }
}
