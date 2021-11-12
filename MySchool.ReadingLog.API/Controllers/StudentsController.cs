using Microsoft.AspNetCore.Mvc;
using MySchool.ReadingLog.API.Models;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services;
using System;
using System.Collections.Generic;

namespace MySchool.ReadingLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public void AddStudent(Student student)
        {
            student.CreatedBy = "Bhavani";
            student.CreatedDate = DateTime.Now;
            student.ModifiedDate = DateTime.Now;
            studentService.AddStudent(student);
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            List<Student> students = studentService.GetStudents();

            List<StudentModel> studentsModel = new List<StudentModel>();
            foreach (var student in students)
            {
                StudentModel studentModel = new StudentModel();
                studentModel.StudentName = student.StudentName;
                studentModel.Grade = student.Grade;
               
                studentModel.BooksReadModel = new List<BookReadModel>();
                foreach(var bookRead in student.BooksRead)
                {
                    studentModel.BooksReadModel.Add(new BookReadModel { BookId = bookRead.BookId, DateRead = bookRead.DateRead,BookName=bookRead.Book.BookName });
                }
                studentsModel.Add(studentModel);
            }
            return Ok(studentsModel);
        }

        [HttpGet]
        [Route("{studentId}")]
        public IActionResult GetStudent(int studentId)
        {
            var student = studentService.GetStudent(studentId);

            StudentModel studentModel = new StudentModel();
            studentModel.StudentName = student.StudentName;
            studentModel.Grade = student.Grade;
            studentModel.BooksReadModel  = new List<BookReadModel>();
            foreach(var bookRead in student.BooksRead)
            {
                
                studentModel.BooksReadModel.Add(new BookReadModel { BookId= bookRead.BookId, DateRead=bookRead.DateRead ,BookName=bookRead.Book.BookName});
            }

            return Ok(studentModel);
        }

        [HttpPut]
        public IActionResult Update(Student student)
        {
            studentService.Update(student);
            return Ok();
        }

        [HttpPost]
        [Route("{studentId}/BooksRead")]
        public IActionResult AddBookRead(int studentId, BookReadModel bookReadModel)
        {

            BookRead bookRead = new BookRead();
            bookRead.BookId = bookReadModel.BookId;
            bookRead.DateRead = bookReadModel.DateRead;
            bookRead.CreatedBy = "Kalyan";
            bookRead.CreatedDate = DateTime.Now;
            studentService.AddBookRead(studentId,bookRead);
            return Ok();
        }
    }
}