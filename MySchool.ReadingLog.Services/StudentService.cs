using MySchool.ReadingLog.DataAccess;
using MySchool.ReadingLog.Domain;
using System.Collections.Generic;

namespace MySchool.ReadingLog.Services
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

        public void AddBookRead(BookRead bookRead)
        {
            studentRepository.AddBookRead(bookRead);
        }

        public List<BookRead> GetBookRead(int studentId)
        {
            return null;
        }

        public Student GetStudent(int studentId)
        {
            return studentRepository.GetStudent(studentId);
        }

        public void Update(Student student)
        {
            studentRepository.Update(student);
        }
    }
}