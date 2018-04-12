using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalClinicWeb.Controllers
{
    public class AppointmentsController : Controller
    {
        // GET: Appointments
        public ActionResult Appointment()
        {
            return View();
        }
    }
}