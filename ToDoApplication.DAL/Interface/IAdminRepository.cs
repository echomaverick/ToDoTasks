using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.DAL.Entities;

namespace ToDoApplication.DAL.Interface
{
    public interface IAdminRepository
    {
        Task<Admin> AddAdmin(Admin model);
        Task<Admin> GetAdminById(int id);
        Task<List<Admin>> GetAllAdmins();
        Task<bool> UpdateAdmin(Admin model);
        Task<bool> DeleteAdmin(Admin model);
        Task<Admin> GetAdmin(string username, string password);
    }
}
