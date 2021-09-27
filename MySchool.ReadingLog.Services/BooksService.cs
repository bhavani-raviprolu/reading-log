using MySchool.ReadingLog.DataAccess;
using MySchool.ReadingLog.Domain;
using System.Collections.Generic;

namespace MySchool.ReadingLog.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository bookRepository;

        public BooksService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            bookRepository.AddBook(book);
        }

        public List<Book> GetBooks()
        {
            return bookRepository.GetBooks();
        }
    }
}