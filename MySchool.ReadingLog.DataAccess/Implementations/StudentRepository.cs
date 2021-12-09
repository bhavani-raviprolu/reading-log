using Microsoft.EntityFrameworkCore;
using MySchool.ReadingLog.DataAccess.Interfaces;
using MySchool.ReadingLog.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.DataAccess.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ReadingLogDbContext readingLogDbContext;

        public StudentRepository(ReadingLogDbContext context)
        {
            readingLogDbContext = context;
        }

        public async Task AddStudentAsync(Student student)
        {
            var parent = readingLogDbContext.Users
                .Include(c => c.Students)
                .FirstOrDefault(c => c.EmailAddress.ToLower().Equals(student.ParentEmailId));

            if (parent == null)
            {
                throw new KeyNotFoundException($"Parent with {student.ParentEmailId} not found.");
            }

            parent.Students.Add(student);

            await readingLogDbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await readingLogDbContext.Students.Include(x => x.BooksRead).ThenInclude(x => x.Book).ToListAsync();
        }

        public async Task AddBookReadAsync(int studentId, BookRead bookRead)
        {
            var student = await readingLogDbContext.Students.FindAsync(studentId);
            if (student.BooksRead == null)
            {
                student.BooksRead = new List<BookRead>();
            }
            student.BooksRead.Add(bookRead);
            readingLogDbContext.Students.Update(student);
            await readingLogDbContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
            return await readingLogDbContext.Students.Include(x => x.BooksRead).ThenInclude(x => x.Book).FirstAsync(x => x.Id == studentId);
        }

        

        public async Task UpdateStudentAsync(int studentId, Student student)
        {
            var current = readingLogDbContext.Students.Find(student.Id);

            current.StudentName = student.StudentName;
            current.Grade = student.Grade;

            await readingLogDbContext.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            var current = readingLogDbContext.Students.Find(studentId);
            readingLogDbContext.Students.Remove(current);
            await readingLogDbContext.SaveChangesAsync();
        }
    }
}