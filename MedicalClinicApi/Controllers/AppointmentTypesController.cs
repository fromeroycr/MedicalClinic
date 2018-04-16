using MedicalClinicDataAccess.Models;
using MedicalClinicRepositories.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MedicalClinicApi.Controllers
{
    [EnableCors(origins: "http://localhost:49715", headers: "*", methods: "*")]
    public class AppointmentTypesController : ApiController
    {
        private IAppointmentTypesRepository _appointmentTypesRepository;

        public AppointmentTypesController(IAppointmentTypesRepository appointmentTypesRepository)
        {
            _appointmentTypesRepository = appointmentTypesRepository;
        }

        // GET: AppointmentTypes
        [HttpGet]
        [Route("api/AppointmentTypes/GetAppointmentTypes")]
        public IEnumerable<AppointmentType> GetAppointmentTypes()
        {
            return _appointmentTypesRepository.GetAppointmentTypes();
        }
    }
}