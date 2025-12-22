using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGECT_LIB.Data.Model
{
    public class Nurse : ApplicationUser
    {

        public int Salary { get; set; }
        public bool IsDeleted { get; set; }



    }
}
