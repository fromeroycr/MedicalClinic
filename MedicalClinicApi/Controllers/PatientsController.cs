using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MedicalClinic.Common;
using MedicalClinicApi.Models;
using MedicalClinicDataAccess.DAL;
using MedicalClinicDataAccess.Models;
using MedicalClinicRepositories.Interfaces;

namespace MedicalClinicApi.Controllers
{
    public class PatientsController : ApiController
    {
        private MedicalClinicContext db = new MedicalClinicContext();
        private IPatientsRepository _patientsRepository;

        public PatientsController(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        // GET: api/Patients
        public IEnumerable<Patient> GetPatients()
        {
            return _patientsRepository.GetPatients();
        }

        // GET: api/Patients/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult GetPatient(int id)
        {
            Patient patient = _patientsRepository.GetPatient(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPost]
        [Route("patients/PutPatient/{PatientID}")]
        public string PutPatient(int patientID, [FromBody] Patient patient)
        {
            var response = _patientsRepository.UpdatePatient(patient);

            if (response.Result == OperationResult.Sucessful)
                return "Patient Updated";
            else
                return "Failed Update";
            
        }

        // POST: api/Patients
        [ResponseType(typeof(Patient))]
        public IHttpActionResult PostPatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseModel responseModel = new ResponseModel();

            try
            {
                responseModel = _patientsRepository.CreatePatient(patient);
            }
            catch (DbUpdateException)
            {
                if (PatientExists(patient.PatientID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = patient.PatientID }, patient);
        }

        // DELETE: api/Patients/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult DeletePatient(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            db.Patients.Remove(patient);
            db.SaveChanges();

            return Ok(patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientExists(int id)
        {
            return _patientsRepository.GetPatients().Count(p => p.PatientID == id) > 0;
        }
    }
}