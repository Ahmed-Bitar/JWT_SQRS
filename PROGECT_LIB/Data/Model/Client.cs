using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROGECT_LIB.Repo;
namespace PROGECT_LIB.Data.Model
{
    public class Client : ApplicationUser, IEntity
    {
        public int Id { get; set; } 
        public string Address { get; set; }
        public int Age { get; set; }
    }
}

