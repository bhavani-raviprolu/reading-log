using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services;
using System;
using System.Collections.Generic;
using MySchool.ReadingLog.API.Models;

namespace MySchool.ReadingLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {    
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpPost]
        public void AddBook(Book book)
        {
            book.CreatedBy = "Kalyan";
            book.CreatedDate = System.DateTime.Now;
            book.ModifiedBy = "Kalyan";
            book.ModifiedDate = System.DateTime.Now;
            booksService.AddBook(book);
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            List<Book> books = booksService.GetBooks();
            List<BookModel> bookModels = new List<BookModel>();
            foreach (var book in books)
            {

                BookModel bookModel = new BookModel();
                bookModel.Id=book.Id;
                bookModel.BookName = book.BookName;
                bookModel.CreatedBy = book.CreatedBy;
                bookModel.CreatedDate = book.CreatedDate;
                bookModel.ModifiedBy = book.ModifiedBy;
                bookModel.ModifiedDate = book.ModifiedDate;
                bookModels.Add(bookModel);

            }
                                   
            return Ok(bookModels);
        }

        [HttpGet]
        [Route("{bookId}")]
        public IActionResult GetBook(int bookId)
        {
            Book book = booksService.GetBook(bookId);
            return Ok(book);
        }
    }
}