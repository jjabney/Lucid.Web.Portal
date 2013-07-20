using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucid.Web.Portal.Models;
using Lucid.Common;

namespace Lucid.Web.Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
           
            if(Request.QueryString["email"] != null && Request.QueryString["secretkey"] != null)
            {
                return RedirectToAction("create", "users", new { userEmail = Request.QueryString["email"], secretpassword = Request.QueryString["secretkey"] });
            }
            return View("Login");
        }

       
    }
}
