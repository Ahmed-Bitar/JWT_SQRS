using Microsoft.AspNetCore.Mvc;

namespace PROGECT_LIB.Servis
{
    public interface IMailService
    {
        Task<IActionResult> SendingTask(int id);
    }
}