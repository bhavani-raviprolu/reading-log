using MySchool.ReadingLog.Domain;
using System.Collections.Generic;

namespace MySchool.ReadingLog.Services
{
    public interface IStudentService
    {
        void AddBookRead(BookRead bookRead);

        void AddStudent(Student student);

        List<BookRead> GetBookRead(int studentId);

        List<Student> GetStudents();
    }
}