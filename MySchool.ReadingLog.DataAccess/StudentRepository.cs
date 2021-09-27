using Microsoft.EntityFrameworkCore;
using MySchool.ReadingLog.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MySchool.ReadingLog.DataAccess
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ReadingLogDbContext readingLogDbContext;
        private readonly ReadingLogDbContext readingLogDbContext1;

        public StudentRepository(ReadingLogDbContext context,ReadingLogDbContext context1)
        {
            readingLogDbContext = context;
            readingLogDbContext1 = context1;
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

        public Student GetStudent(int studentId)
        {
            return readingLogDbContext.Students.First(x => x.Id == studentId);
        }

        public List<BookRead> GetBookRead(int studentId)
        {
            return null;
        }

        public void Update(Student student)
        {
            var current = readingLogDbContext.Students.Find(student.Id);
            readingLogDbContext1.Entry(current).CurrentValues.SetValues(student);
            var changeState = readingLogDbContext1.ChangeTracker.DebugView.LongView;

           
            readingLogDbContext1.SaveChanges();
            
        }
    }
}