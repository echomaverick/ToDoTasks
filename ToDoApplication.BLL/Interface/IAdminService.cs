using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.BLL.DTO;
using ToDoApplication.Common;

namespace ToDoApplication.BLL.Interface
{
    public interface IAdminService
    {
        Task<Admin> AddAdmin(Admin model);
        Task<Admin> GetAdminById(int id);
        Task<List<Admin>> GetAllAdmins();
        Task<bool> UpdateAdmin(Admin model, int id);
        Task<bool> DeleteAdmin(int id);
        Task<SessionPerson> Login(LoginForm model);
    }
}
