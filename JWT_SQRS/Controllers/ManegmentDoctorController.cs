
using System.Net.Mail;
using PROGECT_LIB.Data.Model;
using PROGECT_LIB.Data.ModelDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PROGECT_LIB.Data.DbContext;
using PROGECT_LIB.Data.VerificationCodeModel;

namespace MedicalPark.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    [Authorize(Roles = "Hospital Manager")]
    public class DoctorManagementApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly EmailVerificationService _emailService;
        private readonly  AppDbContext _context;
        private readonly IMemoryCache _cache;

        private static readonly TimeSpan CodeValidityDuration = TimeSpan.FromMinutes(2);

        public DoctorManagementApiController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            EmailVerificationService emailService,
            AppDbContext context,
            IMemoryCache cache)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _context = context;
            _cache = cache;
        }

        [HttpPost("send-verification")]
        public async Task<IActionResult> SendVerification([FromBody] string email)
        {
            if (!IsValidEmail(email))
                return BadRequest(new { message = "Invalid email" });

            if (await _userManager.FindByEmailAsync(email) != null)
                return Conflict(new { message = "Email already exists" });

            var verification = new DoctorVerificationCode
            {
                Email = email,
                DoctorCode = GenerateCode(),
                ManagerCode = GenerateCode(),
                CreatedAt = DateTime.UtcNow
            };

            await _emailService.SendVerificationEmail(email, verification.DoctorCode);
            await _emailService.SendVerificationEmail("ahmad.w.bitar@gmail.com", verification.ManagerCode);

            _cache.Set(email, verification, CodeValidityDuration);

            return Ok(new { message = "Verification codes sent successfully" });
        }

        // ================= VERIFY CODES =================
        [HttpPost("verify")]
        public IActionResult Verify(string email, string doctorCode, string managerCode)
        {
            if (!_cache.TryGetValue(email, out DoctorVerificationCode saved))
                return BadRequest(new { message = "Verification code expired" });

            if (saved.DoctorCode != doctorCode || saved.ManagerCode != managerCode)
                return Unauthorized(new { message = "Invalid verification codes" });

            return Ok(new { message = "Verification successful" });
        }

        // ================= REGISTER DOCTOR =================
        [HttpPost("register")]
        public async Task<IActionResult> RegisterDoctor([FromBody] DoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_cache.TryGetValue(dto.Email, out _))
                return BadRequest(new { message = "Email not verified" });

            var doctor = new Doctor
            {
                FullName = dto.FullName,
                UserName = dto.Email,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender,
                Specialty = dto.DoctorSpecialty,
                Salery = dto.Salery,
                UserType = "Doctor",
                JoindedTime = DateTimeOffset.UtcNow,
                ConditionJoind = "New Doctor"
            };

            var result = await _userManager.CreateAsync(doctor, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (!await _roleManager.RoleExistsAsync("Doctor"))
                await _roleManager.CreateAsync(new ApplicationRole("Doctor"));

            await _userManager.AddToRoleAsync(doctor, "Doctor");

            _cache.Remove(dto.Email);

            return Ok(new { message = "Doctor registered successfully" });
        }

        // ================= HELPERS =================
        private string GenerateCode()
            => new Random().Next(100000, 999999).ToString();

        private bool IsValidEmail(string email)
        {
            try
            {
                return new MailAddress(email).Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

    
}
