using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.BLL.DTO;
using ToDoApplication.BLL.Interface;
using ToDoApplication.DAL.Interface;

//namespace ToDoApplication.BLL.Services
//{
//    internal class ToDoTaskService : IToDoTaskService
//    {
//        public event Action<ToDoTasks> TaskCreated;
//        public event Action<ToDoTasks> TaskDeleted;
//        public event Action<ToDoTasks> TaskUpdated;
//        private readonly IToDoTaskRepository _todoRepos;
//        public ToDoTaskService(IToDoTaskRepository repos)
//        {
//            _todoRepos = repos;
//        }

//        public ToDoTasks AddTask(ToDoTasks model)
//        {
//            try
//            {
//                var task = new DAL.Entities.ToDoTask
//                {
//                    AdminId = model.AdminId,
//                    UserId = model.UserId,
//                    Title = model.Title,
//                };
//                var addedTask = _todoRepos.AddTask(task);
//                TaskCreated?.Invoke(new DTO.ToDoTasks
//                {
//                    AdminId = addedTask.AdminId,
//                    UserId = addedTask.UserId,
//                    Title = addedTask.Title,
//                });
//                Console.WriteLine($"Tasku u shtua: {addedTask.Title} (ID: {addedTask.Id})");
//                return new DTO.ToDoTasks
//                {
//                    AdminId = addedTask.AdminId,
//                    UserId = addedTask.UserId,
//                    Title = addedTask.Title,
//                };
//            }
//            catch (Exception ex)
//            {
//            }
//            return null;
//        }

//        public bool AddUserComment(int id, ToDoTasks model)
//        {
//            try
//            {
//                var task = _todoRepos.GetTaskById(id);
//                if (task != null)
//                {
//                    task.UserComment = model.UserComment;
//                    return _todoRepos.UpdateTask(task);
//                }
//            }
//            catch (Exception ex)
//            {
//            }
//            return false;
//        }

//        public bool DeleteTask(int id)
//        {
//            try
//            {
//                var task = _todoRepos.GetTaskById(id);
//                if (task != null)
//                {
//                    _todoRepos.DeleteTask(task);
//                    TaskDeleted?.Invoke(new DTO.ToDoTasks
//                    {
//                        AdminId = task.AdminId,
//                        UserId = task.UserId,
//                        Title = task.Title,
//                    });
//                    Console.WriteLine($"Tasku u fshi me sukses: {task.Title} (ID: {task.Id})");
//                    return true;
//                }
//            }
//            catch (Exception ex)
//            {
//            }
//            return false;
//        }

//        public List<ToDoTasks> GetAdminTasks(int? id)
//        {
//            try
//            {
//                var tasks = _todoRepos.GetAdminTasks(id);
//                var newList = tasks.Select(x => new DTO.ToDoTasks
//                {
//                    Id = x.Id,
//                    AdminId = x.AdminId,
//                    UserId = x.UserId,
//                    Title = x.Title,
//                    UserComment = x.UserComment,
//                    IsCompleted = x.IsCompleted,
//                }).ToList();
//                return newList;
//            }
//            catch (Exception ex)
//            {
//            }
//            return null;
//        }

//        public ToDoTasks GetTask(int id)
//        {
//            try
//            {
//                var task = _todoRepos.GetTaskById(id);
//                return new DTO.ToDoTasks
//                {
//                    AdminId = task.AdminId,
//                    UserId = task.UserId,
//                    Title = task.Title,
//                    UserComment = task.UserComment,
//                };
//            }
//            catch (Exception ex)
//            {
//            }
//            return null;
//        }

//        public List<ToDoTasks> GetTasks()
//        {
//            try
//            {
//                var tasks = _todoRepos.GetAllTasks();
//                var newList = tasks.Select(x => new DTO.ToDoTasks
//                {
//                    Id = x.Id,
//                    AdminId = x.AdminId,
//                    UserId = x.UserId,
//                    Title = x.Title,
//                    UserComment = x.UserComment,
//                    IsCompleted = x.IsCompleted,
//                }).ToList();
//                return newList;
//            }
//            catch (Exception ex)
//            {
//            }
//            return null;
//        }

//        public List<ToDoTasks> GetUserTasks(int? id)
//        {
//            try
//            {
//                var tasks = _todoRepos.GetUserTasks(id);
//                var newList = tasks.Select(x => new DTO.ToDoTasks
//                {
//                    Id = x.Id,
//                    AdminId = x.AdminId,
//                    UserId = x.UserId,
//                    Title = x.Title,
//                    UserComment = x.UserComment,
//                    IsCompleted = x.IsCompleted,
//                }).ToList();
//                return newList;
//            }
//            catch (Exception ex)
//            {
//            }
//            return null;
//        }

//        public bool MarkAsCompleted(int id, ToDoTasks model)
//        {
//            try
//            {
//                var task = _todoRepos.GetTaskById(id);
//                if (task != null)
//                {
//                    task.IsCompleted = model.IsCompleted;
//                    return _todoRepos.UpdateTask(task);
//                }
//            }
//            catch (Exception ex)
//            {
//            }
//            return false;
//        }

//        public bool UpdateTask(int id, ToDoTasks model)
//        {
//            try
//            {
//                var task = _todoRepos.GetTaskById(id);
//                if (task != null)
//                {
//                    task.Title = model.Title;
//                    task.UserId = model.UserId;

//                    var isUpdated = _todoRepos.UpdateTask(task);
//                    if (isUpdated)
//                    {
//                        TaskUpdated?.Invoke(new DTO.ToDoTasks
//                        {
//                            AdminId = task.AdminId,
//                            UserId = task.UserId,
//                            Title = task.Title,
//                        });
//                        Console.WriteLine($"Tasku u perditesua: {task.Title} (ID: {task.Id})");
//                    }
//                    return isUpdated;
//                }
//            }
//            catch (Exception ex)
//            {
//            }
//            return false;
//        }
//    }
//}


namespace ToDoApplication.BLL.Services
{
    internal class ToDoTaskService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _taskRepository;
        public event Action<DTO.ToDoTasks> TaskCreated;
        public event Action<DTO.ToDoTasks> TaskUpdated;
        public event Action<DTO.ToDoTasks> TaskDeleted;
        public ToDoTaskService(IToDoTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public ToDoTasks AddTask(ToDoTasks model)
        {
            try
            {
                var task = new DAL.Entities.ToDoTask
                {
                    AdminId = model.AdminId,
                    UserId = model.UserId,
                    Title = model.Title,
                };
                var addedTask = _taskRepository.AddTask(task);
                TaskCreated?.Invoke(new DTO.ToDoTasks
                {
                    AdminId = addedTask.AdminId,
                    UserId = addedTask.UserId,
                    Title = addedTask.Title,
                });
                Console.WriteLine($"Tasku u shtua: {addedTask.Title} (ID: {addedTask.Id})");
                return new DTO.ToDoTasks
                {
                    AdminId = addedTask.AdminId,
                    UserId = addedTask.UserId,
                    Title = addedTask.Title,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tasku nuk u shtua me sukses");
            }
            return null;
        }


        public bool DeleteTask(int id)
        {
            try
            {
                var task = _taskRepository.GetTaskById(id);
                if (task != null)
                {
                    _taskRepository.DeleteTask(task);
                    TaskDeleted?.Invoke(new DTO.ToDoTasks
                    {
                        AdminId = task.AdminId,
                        UserId = task.UserId,
                        Title = task.Title,
                    });
                    Console.WriteLine($"Tasku u fshi me sukses: {task.Title} (ID: {task.Id})");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tasku nuk u fshi me sukses");
            }
            return false;
        }

        public DTO.ToDoTasks GetTask(int id)
        {
            try
            {
                var task = _taskRepository.GetTaskById(id);
                return new DTO.ToDoTasks
                {
                    AdminId = task.AdminId,
                    UserId = task.UserId,
                    UserComment = task.UserComment,
                    Title = task.Title,
                };
            }
            catch
            {
                Console.WriteLine("Tasku nuk u gjet");
            }
            return null;
        }

        public List<DTO.ToDoTasks> GetTasks()
        {
            try
            {
                var tasks = _taskRepository.GetAllTasks();
                var newList = tasks.Select(x => new DTO.ToDoTasks
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    UserComment = x.UserComment,
                    AdminId = x.AdminId,
                    IsCompleted = x.IsCompleted,
                    Title = x.Title,
                }).ToList();
                return newList;
            }
            catch
            {
                Console.WriteLine("Nuk u gjenden tasket");
            }
            return null;
        }

        public bool UpdateTask(int id, ToDoTasks model)
        {
            try
            {
                var task = _taskRepository.GetTaskById(id);
                if (task != null)
                {
                    task.Title = model.Title;
                    task.UserId = model.UserId;

                    var isUpdated = _taskRepository.UpdateTask(task);
                    if (isUpdated)
                    {
                        TaskUpdated?.Invoke(new DTO.ToDoTasks
                        {
                            AdminId = task.AdminId,
                            UserId = task.UserId,
                            Title = task.Title,
                        });
                        Console.WriteLine($"Tasku u perditesua: {task.Title} (ID: {task.Id})");
                    }
                    return isUpdated;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tasku nuk u perditesua me sukses");
            }
            return false;
        }

        public bool MarkAsCompleted(int id, DTO.ToDoTasks model)
        {
            try
            {
                var task = _taskRepository.GetTaskById(id);
                if (task != null)
                {
                    task.IsCompleted = model.IsCompleted;
                    return _taskRepository.UpdateTask(task);
                }
            }
            catch
            {
                Console.WriteLine("Nuk mund te shenohet si e kryer me sukses");
            }
            return false;
        }


        public bool AddUserComment(int id, DTO.ToDoTasks model)
        {
            try
            {
                var task = _taskRepository.GetTaskById(id);
                if (task != null)
                {
                    task.UserComment = model.UserComment;
                    return _taskRepository.UpdateTask(task);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Nuk mund te shtohet komenti me sukses");
            }
            return false;
        }

        public List<DTO.ToDoTasks> GetUserTasks(int? id)
        {
            try
            {
                var tasks = _taskRepository.GetUserTasks(id);
                var newList = tasks.Select(x => new DTO.ToDoTasks
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    UserComment = x.UserComment,
                    AdminId = x.AdminId,
                    IsCompleted = x.IsCompleted,
                    Title = x.Title,
                }).ToList();
                return newList;
            }
            catch
            {
                Console.WriteLine("Nuk mund te meren takset e perdoruesit");
            }
            return null;
        }

        public List<DTO.ToDoTasks> GetAdminTasks(int? id)
        {
            try
            {
                var tasks = _taskRepository.GetAdminTasks(id);
                var newList = tasks.Select(x => new DTO.ToDoTasks
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    UserComment = x.UserComment,
                    AdminId = x.AdminId,
                    IsCompleted = x.IsCompleted,
                    Title = x.Title,
                }).ToList();
                return newList;
            }
            catch
            {
                Console.WriteLine("Nuk mund te meren takset e adminit");
            }
            return null;
        }
    }
}
