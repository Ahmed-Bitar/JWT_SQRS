using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROGECT_LIB.Repo;
namespace PROGECT_LIB.Data.Model
{
    public class Doctor : ApplicationUser, IEntity
    {
        public enum DoctorSpecialty
        {
            GeneralPractitioner,
            Cardiologist,
            Dermatologist,
            Neurologist,
            Orthopedic,
            Pediatrician,
            Gynecologist,
            Psychiatrist,
            Surgeon,
            Endocrinologist,
            Urologist,
            ENTDoctor,
            Ophthalmologist,
            Rheumatologist,
            Pathologist,
            Oncologist,
            Anesthesiologist,
            Radiologist,
            FamilyMedicine,
            InternalMedicine,
            Geriatrics
        }
        public DoctorSpecialty Specialty { get; set; }
        public int Salery { get; set; }
        public int PatientID { get; set; }

        public string ConditionJoind { get; set; }
        public DateTimeOffset JoindedTime { get; set; }
        public List<Patient> Patients { get; set; } = [];
        public List<Appointment> Appointments { get; set; } = [];
       // public List<MedicalRecord> MedicalRecords { get; set; } = [];
        public List<Prescription> Prescriptions { get; set; } = [];

    }
}

