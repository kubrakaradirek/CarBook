using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddresses : ControllerBase
    {
        private readonly IMediator _mediator;
        public FooterAddresses(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressesList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddresses(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFooterAddresses(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Alt bilgi başarıyla silindi.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddresses(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt bilgi başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddresses(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt bilgi başarıyla güncellendi.");
        }
    }
}
