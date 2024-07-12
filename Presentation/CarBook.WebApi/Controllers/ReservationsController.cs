using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationSController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationSController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon başarıyla eklendi");
        }
    }
}
