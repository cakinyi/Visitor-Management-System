using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VisitorManagement.Models;

namespace VisitorManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AdminCheck adminCheck = new AdminCheck();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            TempData["res"]=null;
            return RedirectToAction("Index", "Products");
        }
        public IActionResult Privacy()
        {
            return View();
        }
  
        [HttpPost]
        public IActionResult Index([Bind] AdminLogin ad)
        {
             int res = adminCheck.LoginCheck(ad);
            if (res == 1)
            {
                TempData["res"] = res;
                return RedirectToAction("Index", "Products");
            }
            else
            {
                TempData["msg"] = "Admin id or Password is wrong.!";
            }
            return View();
        }
        public IActionResult adminpage()
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
