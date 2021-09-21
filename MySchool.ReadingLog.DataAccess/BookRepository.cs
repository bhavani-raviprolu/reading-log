﻿using MySchool.ReadingLog.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MySchool.ReadingLog.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private ReadingLogDbContext readingLogDbContext;

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
    }
}