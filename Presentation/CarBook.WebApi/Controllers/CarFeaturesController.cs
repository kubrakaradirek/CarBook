using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _meditor;
        public CarFeaturesController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _meditor.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpGet("CarFeatureAvailableChangeToFalse")]
        public async Task<IActionResult> CarFeatureAvailableChangeToFalse(int id)
        {
            _meditor.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("CarFeatureAvailableChangeToTrue")]
        public async Task<IActionResult> CarFeatureAvailableChangeToTrue(int id)
        {
            _meditor.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Güncelleme Yapıldı");
        }

        [HttpPost]
        public async Task<IActionResult> CreeateCarFeatureByCarId(CreateCarFeatureByCarCommand command)
        {
            _meditor.Send(command);
            return Ok("Ekleme Yapıldı");  
        }
    }
}
