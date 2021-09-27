using Microsoft.AspNetCore.Mvc;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services;
using System;
using System.Collections.Generic;

namespace MySchool.ReadingLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost("AddStudent")]
        public void AddStudent(Student student)
        {
            student.CreatedBy = "Bhavani";
            student.CreatedDate = DateTime.Now;
            student.ModifiedDate = DateTime.Now;
            studentService.AddStudent(student);
        }

        [HttpGet("GetStudents")]
        public IActionResult GetStudents()
        {
            List<Student> students = studentService.GetStudents();
            return Ok(students);
        }

        [HttpGet("GetStudent")]
        public IActionResult GetStudent(int studentId)
        {
            var student = studentService.GetStudent(studentId);
            return Ok(student);
        }

        [HttpPut("Update")]
        public IActionResult Update(Student student)
        {
            studentService.Update(student);
            return Ok();
        }
    }
}