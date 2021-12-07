using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.ReadingLog.API.Infrastructure;
using MySchool.ReadingLog.API.Models;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services.Interfaces;
using System.Collections.Generic;

namespace MySchool.ReadingLog.API.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : BaseController
    {
        private readonly IBooksService booksService;

        private readonly IMapper _mapper;

        public BooksController(IBooksService booksService, IMapper mapper)
        {
            this.booksService = booksService;
            this._mapper = mapper;
        }

        [HttpPost]
        [RoleAuthorize(Role.Admin)]
        public void AddBook(BookModel bookModel)
        {
            var book = _mapper.Map<Book>(bookModel);
            booksService.AddBook(book);
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = booksService.GetBooks();
            var bookModels = _mapper.Map<List<BookModel>>(books);

            return Ok(bookModels);
        }

        [HttpGet]
        [Route("{bookId}")]
        public IActionResult GetBook(int bookId)
        {
            var book = booksService.GetBook(bookId);
            var bookModel = _mapper.Map<BookModel>(book);

            return Ok(bookModel);
        }

        [HttpPut]
        [Route("{bookId}")]
        [RoleAuthorize(Role.Admin)]
        public IActionResult UpdateBook(int bookId, Book book)
        {
            booksService.UpdateBook(bookId, book);
            return Ok();
        }

        [HttpDelete]
        [Route("{bookId}")]
        [RoleAuthorize(Role.Admin)]
        public IActionResult DeleteBook(int bookId)
        {
            booksService.DeleteBook(bookId);
            return Ok();
        }
    }
}