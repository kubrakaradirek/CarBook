using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _meditor;
        public BlogsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _meditor.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _meditor.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _meditor.Send(new RemoveBlogCommand(id));
            return Ok("Blog başarıyla silindi.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _meditor.Send(command);
            return Ok("Blog başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _meditor.Send(command);
            return Ok("Blog başarıyla güncellendi.");
        }

        [HttpGet("GetLast3BlogsWithAuthorsList")]
        public async Task<IActionResult> GetLast3BlogsWithAuthorsList()
        {
            var values=await _meditor.Send(new GetLast3BlogsWithAuthorsQuery());
            return Ok(values);
        }

        [HttpGet("GetAllBlogsWithAuthorList")]
        public async Task<IActionResult> GetAllBlogsWithAuthorList()
        {
            var values = await _meditor.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(values);
        }
    }
}
