using Maintenance.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Maintenance.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new PageContentViewModel
            {
                TopContent = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["encodedTopPageContent"]),
                BottomContent = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["encodedBottomPageContent"])
            };
            Response.StatusCode = 503;
            Response.TrySkipIisCustomErrors = true;
            return View(model);
        }
    }
}