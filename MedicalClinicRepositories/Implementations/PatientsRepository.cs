﻿using MedicalClinic.Common;
using MedicalClinicDataAccess.DAL;
using MedicalClinicDataAccess.Models;
using MedicalClinicRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicRepositories.Implementations
{
    public class PatientsRepository : IPatientsRepository
    {
        private MedicalClinicContext db = new MedicalClinicContext();

        public ResponseModel CreatePatient(Patient patient)
        {
            try
            {
                db.Patients.Add(patient);
                db.SaveChanges();

                return new ResponseModel
                {
                    Result = OperationResult.Sucessful,
                    Message = "Patient Created"
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

        public ResponseModel DeletePatient(int idPatient)
        {
            try
            {
                Patient patient = db.Patients.Find(idPatient);
                db.Patients.Remove(patient);
                db.SaveChanges();

                return new ResponseModel
                {
                    Result = OperationResult.Sucessful,
                    Message = "Patient Deleted"
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

        public Patient GetPatient(int idPatient)
        {            
            Patient patient = db.Patients.Find(idPatient);

            return patient;                       
        }

        public async Task<IEnumerable<Patient>>  GetPatients()
        {
            return await db.Patients.ToListAsync();
        }

        public ResponseModel UpdatePatient(Patient patientUpdated)
        {
            try
            {
                Patient patient = db.Patients.Find(patientUpdated.PatientID);
                patient.Age = patientUpdated.Age;
                patient.Appointments = patientUpdated.Appointments;
                patient.Gender = patientUpdated.Gender;
                patient.Name = patientUpdated.Name;
                patient.PatientID = patientUpdated.PatientID;

                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();

                return new ResponseModel
                {
                    Result = OperationResult.Sucessful,
                    Message = "Patient Updated"
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
