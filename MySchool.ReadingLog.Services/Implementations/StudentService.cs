using MySchool.ReadingLog.DataAccess.Interfaces;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services.Interfaces;
using System.Collections.Generic;

namespace MySchool.ReadingLog.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void AddStudent(Student student)
        {
            studentRepository.AddStudent(student);
        }

        public List<Student> GetStudents()
        {
            return studentRepository.GetStudents();
        }

        public void AddBookRead(int studentId, BookRead bookRead)
        {
            studentRepository.AddBookRead(studentId, bookRead);
        }

        public List<BookRead> GetBookRead(int studentId)
        {
            return null;
        }

        public Student GetStudent(int studentId)
        {
            return studentRepository.GetStudent(studentId);
        }

        public void UpdateStudent(int studentId, Student student)
        {
            studentRepository.UpdateStudent(studentId, student);
        }
        public void DeleteStudent(int studentId)
        {
            studentRepository.DeleteStudent(studentId);
        }
    }
}