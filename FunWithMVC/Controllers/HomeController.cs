using FunWithMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FunWithMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            HttpContext.Session.SetString(SessionVariables.SessionKeyUsername, "Current User");
            ViewData["Username"] = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username)
        {
            HttpContext.Session.SetString(SessionVariables.SessionKeyUsername, username);
            ViewData["Username"] = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}