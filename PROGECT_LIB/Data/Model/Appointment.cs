using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGECT_LIB.Data.Model
{
    public class Appointment
    {

        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public DateTime Rendezvous { get; set; }
        public string Sickness { get; set; }
        public int DoctorId { get; set; }


        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public Prescription Prescription { get; set; }

    }
}
