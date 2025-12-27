
using static PROGECT_LIB.Data.Model.Doctor;

namespace PROGECT_LIB.Data.ModelDto
{
    public class DoctorDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DoctorSpecialty DoctorSpecialty { get; set; }

        public string Password { get; set; }
        public int Salery { get; set; }
        public string UserType { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}
