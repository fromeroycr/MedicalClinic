using MedicalClinic.Common;
using MedicalClinicDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicRepositories.Interfaces
{
    public interface IAppointmentsRepository
    {
        ResponseModel CreateAppointment(Appointment appointment);
    }
}
