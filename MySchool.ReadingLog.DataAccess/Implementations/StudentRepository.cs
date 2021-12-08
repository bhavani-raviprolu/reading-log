using Microsoft.EntityFrameworkCore;
using MySchool.ReadingLog.DataAccess.Interfaces;
using MySchool.ReadingLog.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MySchool.ReadingLog.DataAccess.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ReadingLogDbContext readingLogDbContext;

        public StudentRepository(ReadingLogDbContext context)
        {
            readingLogDbContext = context;
        }

        public void AddStudent(Student student)
        {
            var parent = readingLogDbContext.Users
                .Include(c => c.Students)
                .FirstOrDefault(c => c.EmailAddress.ToLower().Equals(student.ParentEmailId));

            if (parent == null)
            {
                throw new KeyNotFoundException($"Parent with {student.ParentEmailId} not found.")
            }

            parent.Students.Add(student);

            readingLogDbContext.SaveChanges();
        }

        public List<Student> GetStudents()
        {
            return readingLogDbContext.Students.Include(x => x.BooksRead).ThenInclude(x => x.Book).ToList();
        }

        public void AddBookRead(int studentId, BookRead bookRead)
        {
            var student = readingLogDbContext.Students.Find(studentId);
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
            return readingLogDbContext.Students.Include(x => x.BooksRead).ThenInclude(x => x.Book).First(x => x.Id == studentId);
        }

        public List<BookRead> GetBookRead(int studentId)
        {
            return null;
        }

        public void UpdateStudent(int studentId, Student student)
        {
            var current = readingLogDbContext.Students.Find(student.Id);

            current.StudentName = student.StudentName;
            current.Grade = student.Grade;

            readingLogDbContext.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var current = readingLogDbContext.Students.Find(studentId);
            readingLogDbContext.Students.Remove(current);
            readingLogDbContext.SaveChanges();
        }
    }
}