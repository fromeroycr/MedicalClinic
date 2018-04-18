using MedicalClinic.Common;
using MedicalClinicDataAccess.Models;
using MedicalClinicRepositories.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MedicalClinicApi.Controllers
{
    [EnableCors(origins: "http://localhost:49715", headers: "*", methods: "*")]
    public class AppointmentsController : ApiController
    {
        private IAppointmentsRepository _appointmentsRepository;

        public AppointmentsController(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        //[HttpPost]
        [ResponseType(typeof(Appointment))]
        [Route("api/Appointments/CreateAppointment")]
        public HttpResponseMessage CreateAppointment(Appointment appointment)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                responseModel = _appointmentsRepository.CreateAppointment(appointment);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error creating appointment");
            }

            return Request.CreateResponse(HttpStatusCode.OK, responseModel.Message);

        }
    }
}
