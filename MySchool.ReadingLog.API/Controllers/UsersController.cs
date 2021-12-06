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
            var result = await _service.Add(user);
            return Ok(_mapper.Map<UserModel>(result));
        }

        [HttpPut]
        [Route("{id}")]
        [RoleAuthorize(Role.Admin)]
        public async Task<ActionResult<UserModel>> Update(int id, Role role)
        {
            var result = await _service.Update(id, role);
            return Ok(_mapper.Map<UserModel>(result));
        }

        [HttpGet]
        [RoleAuthorize(Role.Admin)]
        public async Task<ActionResult<IList<UserModel>>> Get()
        {
            var result = await _service.Get();
            return Ok(_mapper.Map<IList<UserModel>>(result));
        }

        [HttpGet]
        [Route("{id}")]
        [RoleAuthorize(Role.Admin | Role.Parent)]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var result = await _service.Get(id);
            return Ok(_mapper.Map<UserModel>(result));
        }

        [HttpDelete]
        [Route("{id}")]
        [RoleAuthorize(Role.Admin)]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}