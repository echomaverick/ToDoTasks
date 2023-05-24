using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.DAL.Entities;

namespace ToDoApplication.DAL.Interface
{
    public interface IToDoTaskRepository
    {
        ToDoTask AddTask(ToDoTask model);
        ToDoTask GetTaskById(int id);
        List<ToDoTask> GetAllTasks();
        bool UpdateTask(ToDoTask model);
        bool DeleteTask(ToDoTask model);
        List<ToDoTask> GetUserTasks(int? id);
        List<ToDoTask> GetAdminTasks(int? id);
    }
}
