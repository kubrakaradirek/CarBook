using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _meditor;
        public AuthorsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var values = await _meditor.Send(new GetAuthorQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var value = await _meditor.Send(new GetAuthorByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _meditor.Send(new RemoveAuthorCommand(id));
            return Ok("Yazar başarıyla silindi.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            await _meditor.Send(command);
            return Ok("Yazar başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            await _meditor.Send(command);
            return Ok("Yazar başarıyla güncellendi.");
        }
    }
}
