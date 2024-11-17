// using Microsoft.AspNetCore.Mvc;
// using VisitorManagement.data;
// using VisitorManagement.Models;

// namespace VisitorManagement.Controllers
// {
//     public class UserController : Controller
//     {
//         private readonly InventoryContextt Dbcontextt; 
//         public UserController(InventoryContextt contextt)
//         {
//             Dbcontextt = contextt;
//         }
//         // GET: UserController
//         public ActionResult Index()
//         {
//             return View();
//         }

//         [HttpPost]
//         public ActionResult RegisterUser (User user){ 
//             Dbcontextt.User.Add(user);
//             Dbcontextt.SaveChanges();
//             return View(user);
//         }
//         [HttpPost]
//         public ActionResult LogInUser(LogInUser logInUser){
//             var user = Dbcontextt.User.Where(User=> User.Email == logInUser.Email && User.Password== logInUser.Password).FirstOrDefault();
//             if(user== null){
//                 ViewBag.ErrorMessage("User does not exist");
//                 return null;
//             }
//             return RedirectToAction("Index","Home");
//         }
//     }
// }
