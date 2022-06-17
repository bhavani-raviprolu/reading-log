using MySchool.ReadingLog.DataAccess.Interfaces;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MySchool.ReadingLog.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> AddAsync(User user)
        {
            return await _repository.Add(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<User> GetAsync(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<IList<User>> GetAsync()
        {
            return await _repository.Get();
        }

        public async Task<User> UpdateAsync(int id, Role role)
        {
            return await _repository.Update(id, role);
        }

        public async Task<User> GetAsync(string mailId)
        {
            return await _repository.Get(mailId);
        }

        public async Task<bool> IsAllowedAsync(string mailId, int studentId)
        {
            var user = await this.GetAsync(mailId);

            if(user.Role.HasFlag(Role.Admin))
            {
                return true;
            }

            return user.Students.Any(c => c.Id == studentId);
        }
    }
}