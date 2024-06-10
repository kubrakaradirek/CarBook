using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        public CreateAuthorCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog
            {
               AuthorId = request.AuthorId,
               CategoryId = request.CategoryId,
               CoverImageUrl = request.CoverImageUrl,
               CreatedDate = request.CreatedDate,
               Title = request.Title
            });
        }
    }
}
