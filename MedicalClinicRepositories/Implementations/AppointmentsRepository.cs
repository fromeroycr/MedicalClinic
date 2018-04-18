using MedicalClinic.Common;
using MedicalClinicDataAccess.DAL;
using MedicalClinicDataAccess.Models;
using MedicalClinicRepositories.Interfaces;
using System;

namespace MedicalClinicRepositories.Implementations
{
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private MedicalClinicContext db = new MedicalClinicContext();

        public ResponseModel CreateAppointment(Appointment appointment)
        {
            try
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();

                return new ResponseModel
                {
                    Result = OperationResult.Sucessful,
                    Message = "Appointment Created"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Result = OperationResult.Failed,
                    Message = ex.Message
                };
            }
        }
    }
}
