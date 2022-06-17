using AutoMapper;
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
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper, IUserService userService)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._userService = userService;
        }

        [HttpPost]
        [RoleAuthorize(Role.Admin)]
        public async Task<IActionResult> AddStudent(StudentModel studentModel)
        {
            var student = _mapper.Map<Student>(studentModel);

            await _studentService.AddStudentAsync(student);
            return Ok();
        }

        [HttpGet] 
        [RoleAuthorize(Role.Admin)]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync();
           
            return Ok(_mapper.Map<List<StudentModel>>(students));
        }

        [HttpGet]
        [Route("{studentId}")]
        [RoleAuthorize(Role.Admin | Role.Parent)]
        public async Task<IActionResult> GetStudent(int studentId)
        {

            if (!await _userService.IsAllowedAsync(this.GetMail(), studentId))
            {
                return new ForbidResult();
            }

            var student = await _studentService.GetStudentAsync(studentId);
            return Ok(_mapper.Map<StudentModel>(student));
        }

        [HttpPut]
        [RoleAuthorize(Role.Admin)]
        public async Task<IActionResult> UpdateStudent(int studentId, Student student)
        {
            await _studentService.UpdateStudentAsync(studentId, student);
            return Ok();
        }

        [HttpPost]
        [Route("{studentId}/BooksRead")]
        [RoleAuthorize(Role.Parent)]
        public async Task<IActionResult> AddBookRead(int studentId, BookReadModel bookReadModel)
        {
            if (!await _userService.IsAllowedAsync(this.GetMail(), studentId))
            {
                return new ForbidResult();
            }

            var bookRead = _mapper.Map<BookRead>(bookReadModel);

            await _studentService.AddBookReadAsync(studentId, bookRead);

            return Ok();
        }

        [HttpDelete]
        [Route("{studentId}")]
        [RoleAuthorize(Role.Admin)]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            await _studentService.DeleteStudentAsync(studentId);
            return Ok();
        }
    }
}