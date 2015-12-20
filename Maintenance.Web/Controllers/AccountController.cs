using Maintenance.Web.Models;
using System.Web.Mvc;
using System.Web.Security;
using System;
using System.Web.Configuration;

namespace Maintenance.Web.Controllers
{
    public class AccountController : Controller
    {
        private const string DEFAULT_USERNAME = "webadmin";

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            ViewBag.Error = false;
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Form is not valid; please review and try again.";
                return View("Login");
            }

            if (ValidateLogin(login))
            {
                FormsAuthentication.RedirectFromLoginPage(DEFAULT_USERNAME, true);
            }

            ViewBag.Error = true;
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool ValidateLogin(LoginViewModel login)
        {
            string adminPasswordHash = WebConfigurationManager.AppSettings["adminPasswordHash"];
            string providedPasswordHash = Authentication.GeneratePasswordHash(login.Password);
            return providedPasswordHash == adminPasswordHash;
        }
    }
}
