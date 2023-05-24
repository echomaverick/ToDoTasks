using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.DAL.Entities;
using ToDoApplication.DAL.Interface;

namespace ToDoApplication.DAL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddUser(User model)
        {
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteUser(User model)
        {
            _context.Users.Remove(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(string username, string password)
        {
            var users = await _context.Users.ToListAsync();
            foreach (var user in users)
            {
                if (user.Password == password && user.Username == username)
                {
                    return user;
                }

            }
            return null;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> UpdateUser(User model)
        {
            _context.Users.Update(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UsernameExists(string username)
        {
            var users = await _context.Users.ToListAsync();
            return users.Any(x => x.Username == username);
        }

    }
}
