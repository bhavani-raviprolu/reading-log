using Microsoft.AspNetCore.Mvc;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services;
using System;

namespace MySchool.ReadingLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReadController : ControllerBase
    {
        private readonly IStudentService studentService;

        public BookReadController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost("AddBookRead")]
        public void AddBookRead([FromBody] BookRead bookRead)
        {
            bookRead.DateRead = DateTime.Now;
            bookRead.CreatedBy = "Kalyan";
            bookRead.CreatedDate = DateTime.Now;
            studentService.AddBookRead(bookRead);
        }
    }
}