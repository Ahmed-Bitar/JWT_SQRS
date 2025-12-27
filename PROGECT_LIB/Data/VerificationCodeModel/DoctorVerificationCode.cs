using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGECT_LIB.Data.VerificationCodeModel
{
    public class DoctorVerificationCode
    {
        public string Email { get; set; }
        public string DoctorCode { get; set; }
        public string ManagerCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}