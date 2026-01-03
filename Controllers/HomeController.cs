using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Security_Feature_Project.Data;
using Security_Feature_Project.Models;
using Security_Feature_Project.ViewModels;
using System.Diagnostics;

namespace Security_Feature_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Dashboard()
        {
            var role = HttpContext.Session.GetString("Role");

            if (string.IsNullOrEmpty(role))
                return RedirectToAction("Login", "Account");


            if (role == "Admin")
            {
                var viewModel = new AdminDashboardViewModel
                {
                    TotalUsers = _context.Users.Count(),
                    LockedAccounts = _context.Users.Count(u => u.IsLocked),
                    TotalAuditLogs = _context.AuditLogs.Count(),
                    FailedLoginAttempts = _context.AuditLogs.Count(a => !a.Success),
                    SuccessfulLogins = _context.AuditLogs.Count(a => a.Success)
                };

                return View("AdminDashboard", viewModel);
            }
            else
            {
                                return View("UserDashboard");
            }
        }
    }
}
