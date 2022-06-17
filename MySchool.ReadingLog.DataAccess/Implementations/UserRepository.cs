using Microsoft.EntityFrameworkCore;
using MySchool.ReadingLog.DataAccess.Interfaces;
using MySchool.ReadingLog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ReadingLogDbContext context;

        public UserRepository(ReadingLogDbContext context)
        {
            this.context = context;
        }

        public async Task<User> Add(User user)
        {
            if (this.context.Users.Any(c => c.EmailAddress.Equals(user.EmailAddress)))
            {
                throw new InvalidOperationException($"User with {user.EmailAddress} already exists");
            }

            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return user;
        }

        public async Task Delete(int id)
        {
            var current = this.context.Users.Find(id);

            if (current == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found");
            }

            this.context.Users.Remove(current);
            await this.context.SaveChangesAsync();
        }

        public async Task<User> Get(int id)
        {
            return await this.context.Users
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<User>> Get()
        {
            return await this.context.Users.ToListAsync();
        }

        public async Task<User> Update(int id, Role role)
        {
            var current = this.context.Users.Find(id);

            if (current == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found");
            }

            if (current.Role != role)
            {
                current.Role = role;
            }

            await this.context.SaveChangesAsync();

            return current;
        }

        public async Task<User> Get(string mailId)
        {
            return await this.context.Users
                .Include(c=>c.Students)
                .FirstOrDefaultAsync(c => c.EmailAddress.ToLower().Equals(mailId.ToLower()));
        }
    }
}