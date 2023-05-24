using Microsoft.AspNetCore.Mvc;
using ToDoApplication.BLL.DTO;
using ToDoApplication.BLL.Interface;
using ToDoApplication.Common;

namespace ToDoApplication.Controllers
{
    public class AdminsController : BaseController
    {
        private readonly IAdminService _adminService;
        public AdminsController(IAdminService service)
        {
            _adminService = service;
        }
        public async Task<IActionResult> Index()
        {
            if (AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            var admins = await _adminService.GetAllAdmins();
            return View(admins);
        }

        // GET: AdminsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            var admin = await _adminService.GetAdminById(id);
            return View(admin);
        }

        // GET: AdminsController/Create
        public async Task<ActionResult> Create()
        {

            return View(new Admin());
        }

        // POST: AdminsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Admin model)
        {
            var admin = await _adminService.AddAdmin(model);
            if (admin != null)
            {
                return RedirectToAction(nameof(Login));
            }
            return View(model);
        }

        // GET: AdminsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            var admin = await _adminService.GetAdminById(id);
            return View(admin);
        }

        // POST: AdminsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Admin model)
        {
            var admin = await _adminService.UpdateAdmin(model, id);
            if (admin)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: AdminsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (AuthorizePersonInfo == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            var admin = await _adminService.GetAdminById(id);
            return View(admin);
        }

        // POST: AdminsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Admin model)
        {
            var deleted = await _adminService.DeleteAdmin(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (AuthorizePersonInfo != null)
                return RedirectToActionPermanent("Index", "Admins");
            return View(new LoginForm());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginForm model)
        {
            if (AuthorizePersonInfo != null)
                return RedirectToActionPermanent("Index", "Home");
            if (ModelState.IsValid)
            {
                var sessionAdmin = await _adminService.Login(model);
                if (sessionAdmin != null)
                {
                    TempData["AdminId"] = sessionAdmin.Id;
                    HttpContext.Session.SetString("Username", sessionAdmin.Username);
                    HttpContext.Session.SetString("PersonType", sessionAdmin.PersonType.ToString());
                    return RedirectToActionPermanent("Index", "Admins");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            TempData.Remove("AdminId");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
