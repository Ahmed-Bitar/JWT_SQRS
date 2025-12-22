using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROGECT_LIB.Data.Model
{
    public class UserToken
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public ApplicationUser User { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }

}
