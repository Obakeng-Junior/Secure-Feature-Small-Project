using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Security_Feature_Project.Data;
using Security_Feature_Project.Models;

namespace Security_Feature_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private const int MAX_ATTEMPTS = 5;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            
            var failedAttempts = _context.AuditLogs
                .Count(a => a.Username == username && !a.Success);

            if (failedAttempts >= MAX_ATTEMPTS)
            {
                ViewBag.Error = "Account locked due to too many failed attempts.";
                return View();
            }

            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username);

            bool success = user != null &&
                           BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

           
            _context.AuditLogs.Add(new AuditLog
            {
                Username = username,
                AttemptedAt = DateTime.Now,
                Success = success
            });
            _context.SaveChanges();

            if (!success)
            {
                ViewBag.Error = "Invalid username or password.";
                return View();
            }

           
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role.Name);

            return RedirectToAction("Dashboard", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
