using Microsoft.AspNetCore.Mvc;

namespace Sygno.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet("available")]
        public async Task<IActionResult> Available()
        {
            await Task.Delay(1); // Simulación mínima de asincronía
            return Ok(new { status = "available", message = "Service is running" });
        }
    }
}
