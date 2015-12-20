using Maintenance.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Maintenance.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            var model = new PageContentViewModel
            {
                TopContent = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["encodedTopPageContent"]),
                BottomContent = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["encodedBottomPageContent"])
            };
            ViewBag.Submitted = false;
            return View(model);
        }

        // POST: Admin
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(PageContentViewModel model)
        {
            WebConfigurationManager.AppSettings["encodedTopPageContent"] = HttpUtility.HtmlEncode(model.TopContent);
            WebConfigurationManager.AppSettings["encodedBottomPageContent"] = HttpUtility.HtmlEncode(model.BottomContent);
            ViewBag.Submitted = true;
            return View(model);
        }
    }
}