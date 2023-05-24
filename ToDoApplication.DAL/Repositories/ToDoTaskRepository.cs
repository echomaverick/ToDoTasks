using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.DAL.Entities;
using ToDoApplication.DAL.Interface;

namespace ToDoApplication.DAL.Repositories
{
    internal class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly AppDbContext _context;
        public ToDoTaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public ToDoTask AddTask(ToDoTask model)
        {
            _context.ToDoTasks.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteTask(ToDoTask model)
        {
            _context.ToDoTasks.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public List<ToDoTask> GetAdminTasks(int? id)
        {
            var tasks = _context.ToDoTasks.Where(x => x.AdminId == id).ToList();
            if (tasks != null)
            {
                return tasks;
            }
            return null;
        }

        public List<ToDoTask> GetAllTasks()
        {
            var tasks = _context.ToDoTasks.ToList();
            if (tasks != null)
            {
                return tasks;
            }
            return null;
        }

        public ToDoTask GetTaskById(int id)
        {
            return _context.ToDoTasks.Find(id);
        }

        public List<ToDoTask> GetUserTasks(int? id)
        {
            var tasks = _context.ToDoTasks.Where(x => x.UserId == id).ToList();
            if (tasks != null)
            {
                return tasks;
            }
            return null;
        }

        public bool UpdateTask(ToDoTask model)
        {
            _context.ToDoTasks.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
