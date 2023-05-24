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
    internal class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;
        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Admin> AddAdmin(Admin model)
        {
            await _context.Admins.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteAdmin(Admin model)
        {
            _context.Admins.Remove(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Admin> GetAdmin(string username, string password)
        {
            var admins = await _context.Admins.ToListAsync();
            foreach (var admin in admins)
            {
                if (admin.Username == username && admin.Password == password)
                {
                    return admin;
                }
            }
            return null;
        }

        public async Task<Admin> GetAdminById(int id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<bool> UpdateAdmin(Admin model)
        {
            _context.Admins.Update(model);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
