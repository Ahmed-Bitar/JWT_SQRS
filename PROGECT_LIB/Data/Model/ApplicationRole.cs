using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROGECT_LIB.Data.Model
{
    public class ApplicationRole : IdentityRole<int>
    {
   
        public ApplicationRole()
        {
        }


        public ApplicationRole(string roleName) : base(roleName)
        {

        }
    }
}

