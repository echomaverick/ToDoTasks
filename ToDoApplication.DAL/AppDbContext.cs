using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.ToDoTask> ToDoTasks { get; set; }
        public DbSet<Entities.Admin> Admins { get; set; }
    }
}
