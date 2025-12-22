using Microsoft.AspNetCore.Mvc;

namespace JWT_SQRS.Controllers
{
    public class ManegmentDoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
