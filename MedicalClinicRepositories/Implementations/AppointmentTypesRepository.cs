using MedicalClinicDataAccess.DAL;
using MedicalClinicDataAccess.Models;
using MedicalClinicRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicRepositories.Implementations
{
    public class AppointmentTypesRepository : IAppointmentTypesRepository
    {
        private MedicalClinicContext db = new MedicalClinicContext();

        public IEnumerable<AppointmentType> GetAppointmentTypes()
        {
            return db.AppointmentType.ToList();
        }
    }
}
