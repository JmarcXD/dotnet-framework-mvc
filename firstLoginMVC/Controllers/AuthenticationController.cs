using firstLoginMVC.DAL;
using firstLoginMVC.Models;
using System.Web.Mvc;

namespace firstLoginMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserDAL _userDAL;

        public AuthenticationController()
        {
            _userDAL = new UserDAL();
        }

        // GET: Authentication

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {

            LoginViewModel vm = new LoginViewModel();
            vm.Email = Email;
            vm.Password = Password;

            _userDAL.InsertUserToDB(vm);

            ViewBag.Error = "vm.Email";

            return View();

            //return RedirectToAction("Index", "Home");
        }
    }
}