using Microsoft.AspNetCore.Mvc;
using ToDoApplication.BLL.Interface;

namespace ToDoApplication.Controllers
{
    public class ToDoTasksController : BaseController
    {
        private readonly IToDoTaskService _taskService;
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public ToDoTasksController(IToDoTaskService taskService, IAdminService adminService, IUserService userService)
        {
            _taskService = taskService;
            _adminService = adminService;
            _userService = userService;
        }
        // GET: TasksController
        public IActionResult Index()
        {
            return View(_taskService.GetTasks());
        }

        public IActionResult ListUserTasks()
        {
            if(AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            int id = (int)TempData.Peek("UserId");
            return View(_taskService.GetUserTasks(id));
        }
        public IActionResult ListAdminTasks()
        {
            if(AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            int id = (int)TempData.Peek("AdminId");
            return View(_taskService.GetAdminTasks(id));
        }

        // GET: TasksController/Details/5
        public ActionResult Details(int id)
        {
            if(AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View(_taskService.GetTask(id));
        }

        // GET: TasksController/Create
        public async Task<ActionResult> Create()
        {
            if(AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.Users = await _userService.GetAllUsers();
            ViewBag.Admins = await _adminService.GetAllAdmins();
            return View(new BLL.DTO.ToDoTasks());
        }

        // POST: TasksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BLL.DTO.ToDoTasks model)
        {
            var task = _taskService.AddTask(model);
            if (task != null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = await _userService.GetAllUsers();
            ViewBag.Admins = await _adminService.GetAllAdmins();
            return View(model);

        }

        // GET: TasksController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.Users = await _userService.GetAllUsers();
            var task = _taskService.GetTask(id);
            return View(task);
        }

        // POST: TasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BLL.DTO.ToDoTasks model)
        {
            if (_taskService.UpdateTask(id, model))
            {

                return RedirectToAction(nameof(ListAdminTasks));
            }
            ViewBag.Users = await _userService.GetAllUsers();
            return View(model);

        }
        public ActionResult AddUserComment(int id)
        {
            if(AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var task = _taskService.GetTask(id);
            return View(task);
        }

        // POST: TasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUserComment(int id, BLL.DTO.ToDoTasks model)
        {
            var task = _taskService.GetTask(id);
            task.UserComment = model.UserComment;
            if (_taskService.AddUserComment(id, task))
            {
                return RedirectToAction(nameof(ListUserTasks));
            }
            return View(model);

        }

        public ActionResult MarkAsDone(int id)
        {
            if(AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var task = _taskService.GetTask(id);
            return View(task);
        }

        // POST: TasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MarkAsDone(int id, BLL.DTO.ToDoTasks model)
        {
            if (_taskService.MarkAsCompleted(id, model))
            {
                return RedirectToAction(nameof(ListUserTasks));
            }
            return View(model);

        }

        // GET: TasksController/Delete/5
        public ActionResult Delete(int id)
        {
            if(AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var task = _taskService.GetTask(id);
            return View(task);
        }

        // POST: TasksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BLL.DTO.ToDoTasks model)
        {
            var task = _taskService.GetTask(id);
            if (_taskService.DeleteTask(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}