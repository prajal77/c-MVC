using LoginRegi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LoginRegi.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDatabaseContext _context;
        public HomeController(EmployeeDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
               
                return RedirectToAction("Dashboard");

            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Invalid input.";
                return View("Login");
            }
            var userObj = _context.Users
                .FirstOrDefault(u => u.email == user.email && u.password == user.password);
            if (userObj != null)
            {
                //store userObj-Email on "UserSession"
                HttpContext.Session.SetString("UserSession", userObj.email);
                return RedirectToAction("Dashboard");
                
            }
            else
            {
                ViewBag.Message = "Login Failed...";
            }
            return View();
        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");

            }
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
