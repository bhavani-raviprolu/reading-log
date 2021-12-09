using MySchool.ReadingLog.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AddAsync(User user);

        Task<User> UpdateAsync(int id, Role role);

        Task DeleteAsync(int id);

        Task<User> GetAsync(int id);

        Task<IList<User>> GetAsync();

        Task<User> GetAsync(string mailId);

        Task<bool> IsAllowedAsync(string mailId, int studentId);
    }
}