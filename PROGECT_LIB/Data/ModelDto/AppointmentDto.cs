using PROGECT_LIB.Data.Model;

namespace PROGECT_LIB.Data.ModelDto
{
    public class AppointmentDto
    {
        public DateTime Rendezvous { get; set; }
        public string Sickness { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }


    }
}
