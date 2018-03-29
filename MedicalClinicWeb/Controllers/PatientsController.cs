using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicalClinicDataAccess.DAL;
using MedicalClinicDataAccess.Models;
using MedicalClinicWeb.Models;

namespace MedicalClinicWeb.Controllers
{
    public class PatientsController : Controller
    {
        private MedicalClinicContext db = new MedicalClinicContext();

        // GET: Patients
        [HttpGet]
        public JsonResult GetPatients()
        {
            //return View(db.Patients.ToList());
            var result = from patient in db.Patients
                         select new PatientModelViewModel
                         {
                             PatientID = patient.PatientID,
                             Age = patient.Age,
                             Name = patient.Name
                         };

            

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {            
            var result = from patient in db.Patients
                         select new PatientModelViewModel
                         {
                             PatientID = patient.PatientID,
                             Age = patient.Age,
                             Name = patient.Name
                         };

            return View();
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,Name,Age,Gender")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        /*
        // PUT: Patients/5
        public ActionResult PutPatient([Bind(Include = "PatientID,Name,Age,Gender")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }*/

        [HttpPut]
        //public ActionResult PutPatient([Bind(Include = "PatientID,Name,Age,Gender")] Patient patient)
        public ActionResult PutPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                Patient patientToUpdate = db.Patients.Find(patient.PatientID);
                patientToUpdate.Age = patient.Age;
                patientToUpdate.Name = patient.Name;

                db.Entry(patientToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }


        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,Name,Age,Gender")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                Patient patientToUpdate = db.Patients.Find(patient.PatientID);
                patientToUpdate.Age = patient.Age;
                patientToUpdate.Name = patient.Name;                

                db.Entry(patientToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
