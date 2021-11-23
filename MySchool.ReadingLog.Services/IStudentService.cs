using MySchool.ReadingLog.Domain;
using System.Collections.Generic;

namespace MySchool.ReadingLog.Services
{
    public interface IStudentService
    {
        void AddBookRead(int studentId,BookRead bookRead);

        void AddStudent(Student student);

        List<BookRead> GetBookRead(int studentId);

        List<Student> GetStudents();

        Student GetStudent(int studentId);

        void UpdateStudent(int studentId, Student student);
        void DeleteStudent(int studentId);
    }
}