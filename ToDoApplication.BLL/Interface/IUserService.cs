
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.BLL.DTO;
using ToDoApplication.Common;

namespace ToDoApplication.BLL.Interface
{
    public interface IUserService
    {
        Task<User> AddUser(User model);
        Task<User> GetUserById(int id);
        Task<bool> UpdateUser(User model, int id);
        Task<bool> DeleteUser(int id);
        Task<List<User>> GetAllUsers();
        Task<SessionPerson> Login(LoginForm model);

    }
}
