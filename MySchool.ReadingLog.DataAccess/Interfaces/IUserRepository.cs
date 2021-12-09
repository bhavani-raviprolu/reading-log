using MySchool.ReadingLog.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Add(User user);

        Task<User> Update(int id, Role role);

        Task Delete(int id);

        Task<User> Get(int id);

        Task<IList<User>> Get();

        Task<User> Get(string mailId);
    }
}