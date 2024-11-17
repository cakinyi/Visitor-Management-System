using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VisitorManagement.data;
using VisitorManagement.Models;

namespace VisitorManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventoryContextt Dbcontextt;

        public HomeController(ILogger<HomeController> logger, InventoryContextt Dbcontextt)
        {
            _logger = logger;
            Dbcontextt = Dbcontextt;
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
        public ActionResult RegisterUser (User user){ 
            Dbcontextt.User.Add(user);
            Dbcontextt.SaveChanges();
            return View(user);
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
