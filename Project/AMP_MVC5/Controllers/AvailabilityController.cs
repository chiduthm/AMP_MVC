using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPMVC5.Controllers
{
    public class AvailabilityController : Controller
    {
        // GET: Availability
        public ActionResult Index()
        {
            return View();
        }

        // GET: Availability/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Availability/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Availability/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Availability/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Availability/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Availability/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Availability/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
