using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sygno.Booking.Application.Exceptions;
using Sygno.Booking.Application.External.SendGridEmail;
using Sygno.Booking.Application.Features;
using Sygno.Booking.Domain.Models.SendGrid;

namespace Sygno.Booking.Api.Controllers
{
    [Route("api/v1/notification")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class NotificationController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] SendGridRequestModel model,
            [FromServices] ISendGridEmailService sendGridEmailService)
        {
            var data = await sendGridEmailService.Execute(model);

            if (!data)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK));

		}
    }
}
