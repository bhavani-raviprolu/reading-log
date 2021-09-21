using MySchool.ReadingLog.Domain;
using System.Collections.Generic;

namespace MySchool.ReadingLog.DataAccess
{
    public interface IBookRepository
    {
        void AddBook(Book book);

        List<Book> GetBooks();
    }
}