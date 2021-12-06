using MySchool.ReadingLog.DataAccess.Interfaces;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services.Interfaces;
using System.Collections.Generic;

namespace MySchool.ReadingLog.Services.Implementations
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

        public Book GetBook(int bookId)
        {
            return bookRepository.GetBook(bookId);
        }
        public void UpdateBook(int bookId, Book book)
        {
            bookRepository.UpdateBook(bookId, book);
        }
        public void DeleteBook(int bookId)
        {
            bookRepository.DeleteBook(bookId);
        }
    }
}