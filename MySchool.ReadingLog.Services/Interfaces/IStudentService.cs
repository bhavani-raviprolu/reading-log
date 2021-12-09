using MySchool.ReadingLog.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.Services.Interfaces
{
    public interface IStudentService
    {
        Task AddBookReadAsync(int studentId, BookRead bookRead);

        Task AddStudentAsync(Student student);

       // Task<List<BookRead>> GetBookReadAsync(int studentId);

        Task<List<Student>> GetStudentsAsync();

        Task<Student> GetStudentAsync(int studentId);

        Task UpdateStudentAsync(int studentId, Student student);
        Task DeleteStudentAsync(int studentId);
    }
}