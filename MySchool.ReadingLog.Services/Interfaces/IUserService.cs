using MySchool.ReadingLog.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Add(User user);

        Task<User> Update(int id, Role role);

        Task Delete(int id);

        Task<User> Get(int id);

        Task<IList<User>> Get();

        Task<User> Get(string mailId);

        Task<bool> IsAllowed(string mailId, int studentId);
    }
}