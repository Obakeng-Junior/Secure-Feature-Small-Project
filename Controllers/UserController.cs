using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Security_Feature_Project.Data;
using Security_Feature_Project.Models;

namespace Security_Feature_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

       

        public IActionResult Index(string search)
        {
            if (!IsAdmin())
                return Unauthorized();

            var users = _context.Users.Include(u => u.Role).AsQueryable();

            if (!string.IsNullOrEmpty(search))
                users = users.Where(u => u.Username.Contains(search));

            return View(users.ToList());
        }
        public IActionResult ToggleLock(int id)
        {
            if (!IsAdmin())
                return Unauthorized();

            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.IsLocked = !user.IsLocked;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (!IsAdmin())
                return Unauthorized();

            var currentUsername = HttpContext.Session.GetString("Username");
            var user = _context.Users.Find(id);

            if (user != null && user.Username != currentUsername)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddUser()
        {
            if (!IsAdmin())
                return Unauthorized();

            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(string username, string password, int roleId)
        {
            if (!IsAdmin())
                return Unauthorized();

            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                RoleId = roleId
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

       

        public IActionResult AuditLogs()
        {
            if (!IsAdmin())
                return Unauthorized();

            var logs = _context.AuditLogs
                .OrderByDescending(a => a.AttemptedAt)
                .ToList();

            return View(logs);
        }
    }
}
