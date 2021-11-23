﻿using MySchool.ReadingLog.Domain;
using System.Collections.Generic;

namespace MySchool.ReadingLog.Services
{
    public interface IBooksService
    {
        void AddBook(Book book);

        List<Book> GetBooks();

        Book GetBook(int bookId);

        void UpdateBook(int bookId, Book book);
        void DeleteBook(int bookId);
    }
}