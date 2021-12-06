using MySchool.ReadingLog.DataAccess.Interfaces;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Add(User user)
        {
            return await _repository.Add(user);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<User> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<IList<User>> Get()
        {
            return await _repository.Get();
        }

        public async Task<User> Update(int id, Role role)
        {
            return await _repository.Update(id, role);
        }

        public async Task<User> Get(string mailId)
        {
            return await _repository.Get(mailId);
        }
    }
}