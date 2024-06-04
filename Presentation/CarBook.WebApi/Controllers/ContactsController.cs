using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly GetContactByIdQueryResultHandler _getContactByIdQueryResultHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler, GetContactByIdQueryResultHandler getContactByIdQueryResultHandler, GetContactQueryHandler getContactQueryHandler, RemoveContactCommandHandler removeContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _getContactByIdQueryResultHandler = getContactByIdQueryResultHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryResultHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("İletişim bilgisi başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("İletişim bilgisi başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("İletişim bilgisi başarıyla güncellendi.");
        }
    }
}
