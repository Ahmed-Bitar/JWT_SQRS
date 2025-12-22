using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PROGECT_LIB.Data;
using PROGECT_LIB.Data.Model;
using PROGECT_LIB.Repo;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace JWT_SQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController<T> : ControllerBase where T : class, IEntity
    {
        private readonly EmailVerificationService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly BaseRepo<T> _baseRepo;

        private static readonly TimeSpan CodeValidityDuration = TimeSpan.FromMinutes(1.5);

        public AccountController(
            AppDbContext context,
            BaseRepo<T> baseRepo,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController<T>> logger,
            EmailVerificationService mailService)
        {
            _baseRepo = baseRepo;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailService = mailService;
        }

      

        [HttpPost("send-verification-code")]
        public async Task<IActionResult> SendVerificationCode([FromBody] string email)
        {
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
                return BadRequest(new { success = false, message = "Invalid email address." });

            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
                return BadRequest(new { success = false, message = "Email already associated with an account." });

            var verificationCode = GenerateVerificationCode();
            var codeGeneratedTime = DateTime.UtcNow;

            bool emailSent = await _emailService.SendVerificationEmail(email, verificationCode);
            if (emailSent)
            {
                HttpContext.Session.SetString("VerificationCode", verificationCode);
                HttpContext.Session.SetString("CodeGeneratedTime", codeGeneratedTime.ToString());
                HttpContext.Session.SetString("PatientEmail", email);

                return Ok(new { success = true, message = "Verification code sent." });
            }

            return StatusCode(500, new { success = false, message = "Failed to send email." });
        }

        [HttpPost("verify-code")]
        public IActionResult VerifyCode([FromBody] string code)
        {
            var savedCode = HttpContext.Session.GetString("VerificationCode");
            var timeString = HttpContext.Session.GetString("CodeGeneratedTime");

            if (string.IsNullOrEmpty(savedCode) || string.IsNullOrEmpty(timeString))
                return BadRequest(new { success = false, message = "Verification code expired or not found." });

            if (!DateTime.TryParse(timeString, out var codeGeneratedTime))
                return BadRequest(new { success = false, message = "Invalid code generation time." });

            if (code != savedCode)
                return BadRequest(new { success = false, message = "Invalid code." });

            var timeElapsed = DateTime.UtcNow - codeGeneratedTime;
            if (timeElapsed > CodeValidityDuration)
                return BadRequest(new { success = false, message = "Code expired." });

            return Ok(new { success = true, message = "Code verified." });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string roleName = "Clint";

            var clinte = new Client
            {
                FullName = model.Name,
                Address = model.Adres,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserType = "Clint",
                Gender = model.Gender,
            };

            var result = await _userManager.CreateAsync(clinte, model.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (!await _roleManager.RoleExistsAsync(roleName))
                await _roleManager.CreateAsync(new ApplicationRole(roleName));

            await _userManager.AddToRoleAsync(clinte, roleName);
            await _signInManager.SignInAsync(clinte, isPersistent: false);

            return Ok(new { success = true, message = "User registered successfully." });
        }

       

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            return Ok(user);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { success = true, message = "Logged out successfully." });
        }

        private string GenerateVerificationCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
