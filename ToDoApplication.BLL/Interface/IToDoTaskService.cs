using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.BLL.DTO;

namespace ToDoApplication.BLL.Interface
{
    public interface IToDoTaskService
    {
        event Action<ToDoTasks> TaskCreated;
        ToDoTasks AddTask(DTO.ToDoTasks model);
        ToDoTasks GetTask(int id);
        List<ToDoTasks> GetTasks();
        List<ToDoTasks> GetUserTasks(int? id);
        List<ToDoTasks> GetAdminTasks(int? id);

        bool UpdateTask(int id, ToDoTasks model);
        bool DeleteTask(int id);
        bool MarkAsCompleted(int id, ToDoTasks model);
        bool AddUserComment(int id, ToDoTasks model);
    }
}
