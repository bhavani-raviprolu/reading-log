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
    public class UsersController : BaseController
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpPost]
        [RoleAuthorize(Role.Admin)]
        public async Task<ActionResult<UserModel>> Add(AddUserModel model)
        {
            var user = _mapper.Map<User>(model);
            var result = await _service.AddAsync(user);
            return Ok(_mapper.Map<UserModel>(result));
        }

        [HttpPut]
        [Route("{id}")]
        [RoleAuthorize(Role.Admin)]
        public async Task<ActionResult<UserModel>> Update(int id, UpdateUserModel user)
        {
            var result = await _service.UpdateAsync(id, user.Role);
            return Ok(_mapper.Map<UserModel>(result));
        }

        [HttpGet]
        [RoleAuthorize(Role.Admin)]
        public async Task<ActionResult<IList<UserModel>>> Get()
        {
            var result = await _service.GetAsync();
            return Ok(_mapper.Map<IList<UserModel>>(result));
        }

        [HttpGet]
        [Route("{id}")]
        [RoleAuthorize(Role.Admin | Role.Parent)]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var result = await _service.GetAsync(id);
            return Ok(_mapper.Map<UserModel>(result));
        }

        [HttpDelete]
        [Route("{id}")]
        [RoleAuthorize(Role.Admin)]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}