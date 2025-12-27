using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROGECT_LIB.Data.Model;

namespace PROGECT_LIB.Data.ModelDto
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }
        public string Adres { get; set; }

        public BloodType BloodType { get; set; }
        public MedicalCondition MedicalCondition { get; set; }

        public string DiseaseName { get; set; }
        public string? HistoryOfIllness { get; set; }
    }
}
