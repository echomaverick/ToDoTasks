using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.BLL.DTO;
using ToDoApplication.BLL.Interface;
using ToDoApplication.Common;
using ToDoApplication.Common.Enums;
using ToDoApplication.DAL.Interface;

namespace ToDoApplication.BLL.Services
{
    internal class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepos;
        public AdminService(IAdminRepository repos)
        {
            _adminRepos = repos;
        }
        public async Task<Admin> AddAdmin(Admin model)
        {
            try
            {
                var admin = new DAL.Entities.Admin
                {
                    Name = model.Name,
                    Username = model.Username,
                    Password = model.Password,
                    PersonType = PersonType.Admin
                };
                var addedAdmin = await _adminRepos.AddAdmin(admin);
                if (addedAdmin != null)
                {
                    return new Admin
                    {
                        Name = addedAdmin.Name,
                        Username = addedAdmin.Username,
                        Password = addedAdmin.Password,
                        PersonType = PersonType.Admin
                    };
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<bool> DeleteAdmin(int id)
        {
            try
            {
                var admin = await _adminRepos.GetAdminById(id);
                if (admin != null)
                {
                    return await _adminRepos.DeleteAdmin(admin);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        public async Task<Admin> GetAdminById(int id)
        {
            try
            {
                var admin = await _adminRepos.GetAdminById(id);
                if (admin != null)
                {
                    return new DTO.Admin
                    {
                        Id = admin.Id,
                        Name = admin.Name,
                        Username = admin.Username,
                    };
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            try
            {
                var admins = await _adminRepos.GetAllAdmins();
                var newList = admins.Select(x => new Admin
                {
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username,
                }).ToList();
                return newList;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<SessionPerson> Login(LoginForm model)
        {
            try
            {
                var adminSession = await _adminRepos.GetAdmin(model.Username, model.Password);
                if (adminSession != null)
                {
                    return new SessionPerson
                    {
                        Id = adminSession.Id,
                        Username = adminSession.Username,
                        PersonType = PersonType.Admin
                    };
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<bool> UpdateAdmin(Admin model, int id)
        {
            try
            {
                var admin = await _adminRepos.GetAdminById(id);
                if (admin != null)
                {
                    admin.Name = model.Name;
                    admin.Username = model.Username;
                    admin.Password = model.Password;
                    return await _adminRepos.UpdateAdmin(admin);
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
