using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services;
using System;
using System.Collections.Generic;

namespace MySchool.ReadingLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {    
        private readonly IBooksService booksService;

        public BookController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpPost("AddBook")]
        public void AddBook(Book book)
        {
            book.CreatedBy = "Kalyan";
            book.CreatedDate = System.DateTime.Now;
            book.ModifiedBy = "Kalyan";
            book.ModifiedDate = System.DateTime.Now;
            booksService.AddBook(book);
        }

        [HttpGet("GetBooks")]
        public IActionResult GetBooks()
        {
            List<Book> books = booksService.GetBooks();
            return Ok(books);
        }
    }
}