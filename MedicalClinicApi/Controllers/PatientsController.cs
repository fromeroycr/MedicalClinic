using MedicalClinic.Common;
using MedicalClinicApi.Models;
using MedicalClinicDataAccess.DAL;
using MedicalClinicDataAccess.Models;
using MedicalClinicRepositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Data.Entity;


namespace MedicalClinicApi.Controllers
{
    

    //[EnableCors(origins: "http://localhost:49715,http://localhost:4200", headers: "*", methods: "*")]    
    public class PatientsController : ApiController
    {
        private MedicalClinicContext db = new MedicalClinicContext();
        private IPatientsRepository _patientsRepository;

        public PatientsController(IPatientsRepository patientsRepository)
        {
            var value = System.Configuration.ConfigurationManager.AppSettings["PFUserName"];
            _patientsRepository = patientsRepository;
        }

        // GET: api/Patients        
        //[HttpGet]
        //[Route("api/Patients/GetPatients")]
        //public List<PatientModelViewModel> GetPatients()
        //{
        //    var result = (from patient in _patientsRepository.GetPatients()
        //            select new PatientModelViewModel
        //            {
        //                PatientID = patient.PatientID,
        //                Age = patient.Age,
        //                Name = patient.Name,
        //                Gender = patient.Gender
        //            }
        //            );

        //    return result.ToList();
        //}

        [HttpGet]
        [Route("api/Patients/GetPatients")]
        public async  Task<IEnumerable<PatientModelViewModel>> GetPatients()
        {
            
            var patientsList = await ( _patientsRepository.GetPatients() );


            var result = (from patient in patientsList
                          select new PatientModelViewModel
                          {
                              PatientID = patient.PatientID,
                              Age = patient.Age,
                              Name = patient.Name,
                              Gender = patient.Gender
                          }
                    );
            return result;
        }        

        [HttpGet]
        [Route("api/Patients/GetPatient/{id}")]
        [ResponseType(typeof(PatientModelViewModel))]
        public IHttpActionResult GetPatient(int id)
        {
            Patient patient = _patientsRepository.GetPatient(id);
            if (patient == null)
            {
                return NotFound();
            }

            var result = new PatientModelViewModel
            {
                Age = patient.Age,
                Name = patient.Name,
                PatientID = patient.PatientID

            };
                
            return Ok(patient);
        }

        [HttpPut]
        [Route("api/Patients/PutPatient")]
        public string PutPatient([FromBody] Patient patient)
        {
            var response = _patientsRepository.UpdatePatient(patient);

            if (response.Result == OperationResult.Sucessful)
                return "Patient Updated";
            else
                return "Failed Update";
        }

        // POST: api/Patient
        [ResponseType(typeof(Patient))]
        public async Task<HttpResponseMessage> PostPatient(Patient patient)
        {

            ResponseModel responseModel = new ResponseModel();

            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage
                {                     
                    StatusCode = HttpStatusCode.BadRequest
                };
            }            

            try
            {
                responseModel = _patientsRepository.CreatePatient(patient);
            }
            catch (DbUpdateException)
            {
                if (await PatientExists(patient.PatientID))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, responseModel.Message);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, responseModel.Message);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, responseModel.Message);
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

        private async Task<bool> PatientExists(int id)
        {
            var patientsList = await(_patientsRepository.GetPatients());

            return patientsList.Count(p => p.PatientID == id) > 0;
            //return _patientsRepository.GetPatients().Count(p => p.PatientID == id) > 0;
        }
    }
}