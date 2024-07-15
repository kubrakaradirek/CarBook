using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistersController : ControllerBase
	{
		private readonly IMediator _meditor;
		public RegistersController(IMediator meditor)
		{
			_meditor = meditor;
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser(CreateAppUserCommand command)
		{
			await _meditor.Send(command);
			return Ok("Kullanıcı başarıyla oluşturuldu");
		}
	}
}
