using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPMVC5.Controllers
{
    public class MainPageController : Controller
    {
        // GET: MainPage
        public ActionResult Index()
        {
            ServiceReference1.Service1Client objLocService = new ServiceReference1.Service1Client();
            return View(objLocService.getLocation());
        }
    }
}