using AMP_MVC5.DataAccess;
using AMPMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webmap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Location objLocation = new Location();
            DataAccessLayer objDB = new DataAccessLayer();
            objLocation.ShowallLocation = objDB.SelectallLocationdata();
            // return View(model);
            return View(objLocation);
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is my applicatin discription!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}