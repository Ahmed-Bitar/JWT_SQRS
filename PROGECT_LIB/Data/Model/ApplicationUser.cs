using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROGECT_LIB.Data.Model
{
    public class ApplicationUser : IdentityUser<int>
    {

        public string FullName { get; set; }

        
        public string UserType { get; set; }
        public string Gender { get; set; }
        public bool IsDeleted { get; set; } = false;

       
    }
}
