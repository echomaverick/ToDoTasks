using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.BLL.Interface;
using ToDoApplication.BLL.Services;
using ToDoApplication.DAL;

namespace ToDoApplication.BLL
{
    public static class Startup
    {
        public static void RegisterBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDalServices(configuration.GetConnectionString("DefaultConnection"));
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IToDoTaskService, ToDoTaskService>();
        }
    }
}
