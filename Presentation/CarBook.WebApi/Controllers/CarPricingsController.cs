using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _meditor;
        public CarPricingsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet("GetCarPricingWithCarList")]
        public async Task<IActionResult> GetCarPricingWithCarList()
        {
            var values = await _meditor.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }
        [HttpGet("GetCarPricingWithTimePeriodList")]
		public async Task<IActionResult> GetCarPricingWithTimePeriodList()
		{
			var values = await _meditor.Send(new GetCarPricingWithTimePeriodQuery());
			return Ok(values);
		}

	}
}
