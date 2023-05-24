using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.DAL.Entities;

namespace ToDoApplication.DAL.Interface
{
    public interface IUserRepository
    {
        Task<User> AddUser(User model);
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUser(string username, string password);
        Task<List<User>> GetAllUsers();
        Task<bool> UpdateUser(User model);
        Task<bool> DeleteUser(User model);
        Task<bool> UsernameExists(string username);
    }
}
