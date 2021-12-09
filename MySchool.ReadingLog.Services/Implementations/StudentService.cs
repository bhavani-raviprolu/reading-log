using MySchool.ReadingLog.DataAccess.Interfaces;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
           _studentRepository = studentRepository;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddStudentAsync(student);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }

        public async Task AddBookReadAsync(int studentId, BookRead bookRead)
        {
            await _studentRepository.AddBookReadAsync(studentId, bookRead);
        }

       
        public async Task<Student> GetStudentAsync(int studentId)
        {
            return await _studentRepository.GetStudentAsync(studentId);
        }

        public async Task UpdateStudentAsync(int studentId, Student student)
        {
            await _studentRepository.UpdateStudentAsync(studentId, student);
        }
        public async Task DeleteStudentAsync(int studentId)
        {
            await _studentRepository.DeleteStudentAsync(studentId);
        }
    }
}