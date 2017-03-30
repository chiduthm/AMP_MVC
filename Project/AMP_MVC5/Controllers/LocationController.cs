using AMP_MVC5.DataAccess;
using AMPMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AMP_MVC5.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            Location objLocation = new Location();
            DataAccessLayer objDB = new DataAccessLayer();
            objLocation.ShowallLocation = objDB.SelectallLocationdata();
            // return View(model);
            return View(objLocation);

        }

      

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(Location objLocation)
        {
            try
            {
                // TODO: Add insert logic here

                //return RedirectToAction("Index");

                
                if (ModelState.IsValid) //checking model is valid or not
                {
                    DataAccessLayer objDB = new DataAccessLayer();
                    string result = objDB.InsertLocData(objLocation);
                    ViewData["result"] = result;
                    ModelState.Clear(); //clearing model
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            Location objLocation = new Location();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            return View(objDB.SelectLocationDatabyID(id.ToString()));
            
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Location objLoc)
        {
            try
            {
                // TODO: Add update logic here

                // return RedirectToAction("Index");

                
                if (ModelState.IsValid) //checking model is valid or not
                {
                    DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
                    string result = objDB.UpdateLocationData(objLoc);
                    ViewData["result"] = result;
                    ModelState.Clear(); //clearing model
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
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
