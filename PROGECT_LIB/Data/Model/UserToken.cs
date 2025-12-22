using System.ComponentModel.DataAnnotations;

namespace PROGECT_LIB.Data.Model
{
    public class UserToken
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; }             
        public ApplicationUser? User { get; set; }   

        [Required]
        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
