using MySchool.ReadingLog.Domain;
using System.Collections.Generic;

namespace MySchool.ReadingLog.DataAccess
{
    public interface IStudentRepository
    {
        void AddBookRead(BookRead bookRead);

        void AddStudent(Student student);

        List<BookRead> GetBookRead(int studentId);

        List<Student> GetStudents();
    }
}