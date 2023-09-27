using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB.API.Jarvis.Models;
using WEB.API.Jarvis.Utilities;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        [HttpGet("pruebaLog")]
        public async Task<IActionResult> PruebaLog()
        {
            LoggerService.Info("Prueba1");
            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = " Success", Message = "Email Verified Successfully" });

        }
    }
}
