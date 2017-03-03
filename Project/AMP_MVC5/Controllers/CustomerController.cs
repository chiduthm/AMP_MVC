using AMP_MVC5.DataAccess;
using AMP_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMP_MVC5.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            objCustomer.ShowallCustomer = objDB.Selectalldata();
            return View(objCustomer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer objCustomer)
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}

            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);
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

        [HttpPost]
        public ActionResult InsertCustomer(Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            return View(objDB.SelectDatabyID(id.ToString()));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer objCustomer)
        {
            try
            {
                // TODO: Add update logic here

                // return RedirectToAction("Index");

                objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
                if (ModelState.IsValid) //checking model is valid or not
                {
                    DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
                    string result = objDB.UpdateData(objCustomer);
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
