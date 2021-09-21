using Microsoft.EntityFrameworkCore;
using MySchool.ReadingLog.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MySchool.ReadingLog.DataAccess
{
    public class StudentRepository : IStudentRepository
    {
        private ReadingLogDbContext readingLogDbContext;

        public StudentRepository(ReadingLogDbContext context)
        {
            readingLogDbContext = context;
        }

        public void AddStudent(Student student)
        {
            readingLogDbContext.Students.Add(student);
            readingLogDbContext.SaveChanges();
        }

        public List<Student> GetStudents()
        {
            return readingLogDbContext.Students.Include(x => x.BooksRead).ToList();
        }

        public void AddBookRead(BookRead bookRead)
        {
            var student = readingLogDbContext.Students.Find(bookRead.StudentId);
            if (student.BooksRead == null)
            {
                student.BooksRead = new List<BookRead>();
            }
            student.BooksRead.Add(bookRead);
            readingLogDbContext.Students.Update(student);
            readingLogDbContext.SaveChanges();
        }

        public List<BookRead> GetBookRead(int studentId)
        {
            return null;
        }
    }
}