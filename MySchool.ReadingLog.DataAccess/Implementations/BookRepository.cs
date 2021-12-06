using MySchool.ReadingLog.DataAccess.Interfaces;
using MySchool.ReadingLog.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MySchool.ReadingLog.DataAccess.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly ReadingLogDbContext readingLogDbContext;


        public BookRepository(ReadingLogDbContext readingLogDbContext)
        {
            this.readingLogDbContext = readingLogDbContext;
        }

        public void AddBook(Book book)
        {
            readingLogDbContext.Books.Add(book);
            readingLogDbContext.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            return readingLogDbContext.Books.ToList();
        }

        public Book GetBook(int bookId)
        {
            return readingLogDbContext.Books.First(x => x.Id == bookId);
        }

        public void UpdateBook(int bookId, Book book)
        {
            var current = readingLogDbContext.Books.Find(book.Id);
            current.BookName = book.BookName;
            readingLogDbContext.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var current = readingLogDbContext.Books.Find(bookId);
            readingLogDbContext.Books.Remove(current);
            readingLogDbContext.SaveChanges();
        }
    }
}