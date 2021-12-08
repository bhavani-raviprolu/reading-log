﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.ReadingLog.API.Infrastructure;
using MySchool.ReadingLog.API.Models;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : BaseController
    {
        private readonly IStudentService studentService;
        private readonly IUserService userService;

        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper, IUserService userService)
        {
            this.studentService = studentService;
            this._mapper = mapper;
            this.userService = userService;
        }

        [HttpPost]
        [RoleAuthorize(Role.Admin)]
        public IActionResult AddStudent(StudentModel studentModel)
        {
            var student = _mapper.Map<Student>(studentModel);

            studentService.AddStudent(student);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = studentService.GetStudents();
            var studentsModel = _mapper.Map<List<StudentModel>>(students);

            return Ok(studentsModel);
        }

        [HttpGet]
        [Route("{studentId}")]
        [RoleAuthorize(Role.Admin | Role.Parent)]
        public IActionResult GetStudent(int studentId)
        {
            var student = studentService.GetStudent(studentId);

            var studentModel = _mapper.Map<StudentModel>(student);

            return Ok(studentModel);
        }

        [HttpPut]
        [RoleAuthorize(Role.Admin)]
        public IActionResult UpdateStudent(int studentId, Student student)
        {
            studentService.UpdateStudent(studentId, student);
            return Ok();
        }

        [HttpPost]
        [Route("{studentId}/BooksRead")]
        [RoleAuthorize(Role.Parent)]
        public async Task<IActionResult> AddBookRead(int studentId, BookReadModel bookReadModel)
        {
            if (!await userService.IsAllowed(this.GetMail(), studentId))
            {
                return new ForbidResult();
            }

            var bookRead = _mapper.Map<BookRead>(bookReadModel);

            studentService.AddBookRead(studentId, bookRead);

            return Ok();
        }

        [HttpDelete]
        [Route("{studentId}")]
        [RoleAuthorize(Role.Admin)]
        public IActionResult DeleteStudent(int studentId)
        {
            studentService.DeleteStudent(studentId);
            return Ok();
        }
    }
}