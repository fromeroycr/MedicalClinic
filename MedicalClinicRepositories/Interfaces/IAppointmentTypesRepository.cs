using MedicalClinicDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicRepositories.Interfaces
{
    public interface IAppointmentTypesRepository
    {
        IEnumerable<AppointmentType> GetAppointmentTypes();
    }
}
