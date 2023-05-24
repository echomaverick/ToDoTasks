using Microsoft.AspNetCore.Mvc;
using ToDoApplication.BLL.DTO;
using ToDoApplication.BLL.Interface;
using ToDoApplication.Common;

namespace ToDoApplication.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            if (AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var users = await _userService.GetAllUsers();
            return View(users);
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var admin = await _userService.GetUserById(id);
            return View(admin);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View(new User());
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User model)
        {
            var user = await _userService.AddUser(model);
            if (user != null)
            {
                return RedirectToAction(nameof(Login));
            }
            return View();

        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var user = await _userService.GetUserById(id);
            return View(user);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, User model)
        {
            if (AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var updated = await _userService.UpdateUser(model, id);
            if (updated)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var user = await _userService.GetUserById(id);
            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, User model)
        {
            var deleted = await _userService.DeleteUser(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (AuthorizePersonInfo != null)
                return RedirectToActionPermanent("Index", "Users");
            return View(new LoginForm());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginForm model)
        {
            if (AuthorizePersonInfo != null)
                return RedirectToActionPermanent("Index", "Home");
            if (ModelState.IsValid)
            {
                var sessionUser = await _userService.Login(model);
                if (sessionUser != null)
                {
                    TempData["UserId"] = sessionUser.Id;
                    HttpContext.Session.SetString("Username", sessionUser.Username);
                    HttpContext.Session.SetString("PersonType", sessionUser.PersonType.ToString());
                    return RedirectToActionPermanent("Index", "Users");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            TempData.Remove("UserId");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
