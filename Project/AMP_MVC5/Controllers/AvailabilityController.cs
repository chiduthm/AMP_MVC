using AMP_MVC5.DataAccess;

using AMPMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AMPMVC5.Controllers
{
    public class AvailabilityController : Controller
    {
        // GET: Availability
        public ActionResult Index()

        {

            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                }
            }
            return View();
        }

        public JsonResult GetDiarySummary(double start, double end)
        {
            //var ApptListForDate = AMPEvents.LoadAppointmentSummaryInDateRange(start, end);
            //var eventList = from e in ApptListForDate
            //                select new
            //                {
            //                    id = e.ID,
            //                    title = e.Title,
            //                    start = e.StartDateString,
            //                    end = e.EndDateString,
            //                    someKey = e.SomeImportantKeyID,
            //                    allDay = false
            //                };
            //var rows = eventList.ToArray();
            AppointmentDiary objAppointment = new AppointmentDiary();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            string userIdValue = string.Empty;
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    userIdValue = userIdClaim.Value;
                }
            }

            objAppointment.ShowallAppointment = objDB.SelectallAvailabilitydata(userIdValue);
            //return View(objCustomer);
            string jsonData = new JavaScriptSerializer().Serialize(Json(objAppointment.ShowallAppointment, JsonRequestBehavior.AllowGet));
            string json = new JavaScriptSerializer().Serialize(objAppointment.ShowallAppointment);
            return Json(objAppointment.ShowallAppointment, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDiaryEvents(double start, double end)
        {
            //var ApptListForDate = AMPEvents.LoadAllAppointmentsInDateRange(start, end);
            //var eventList = from e in ApptListForDate
            //                select new
            //                {
            //                    id = e.ID,
            //                    title = e.Title,
            //                    start = e.StartDateString,
            //                    end = e.EndDateString,
            //                    color = e.StatusColor,
            //                    className = e.ClassName,
            //                    someKey = e.SomeImportantKeyID,
            //                    allDay = false
            //                };
            //var rows = eventList.ToArray();
            //string jsonData = new JavaScriptSerializer().Serialize(Json(rows, JsonRequestBehavior.AllowGet));
            //string json = new JavaScriptSerializer().Serialize(rows);
            string userIdValue = string.Empty;
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    userIdValue = userIdClaim.Value;
                }
            }


            AppointmentDiary objAppointment = new AppointmentDiary();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            objAppointment.ShowallAppointment = objDB.SelectallAvailabilitydata(userIdValue);

            return Json(objAppointment, JsonRequestBehavior.AllowGet);
        }

        public bool SaveEvent(string Title, string NewEventDate, string NewEventTime, string NewEventDuration)
        {
            return AMPEvents.CreateNewEvent(Title, NewEventDate, NewEventTime, NewEventDuration);
        }

        public string Init()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                }
            }
            return "test";
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
