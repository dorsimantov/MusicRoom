using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Music.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Check if user is registered, if not redirect to registration page
            //if (AuthenticatedUsername() != string.Empty) return View("Index");
            //else return RedirectToAction("NewUser", "User");

            return View("Index");
        }

        public ActionResult Error()
        {
            return View("Error");
        }
    }
}