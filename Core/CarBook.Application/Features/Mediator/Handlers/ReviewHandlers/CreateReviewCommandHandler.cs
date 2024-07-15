﻿using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
	{
		private readonly IRepository<Review> _repository;
		public CreateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Review
			{
				CustomerIamge = request.CustomerIamge,
				CarId = request.CarId,
				Comment = request.Comment,
				CustomerName = request.CustomerName,
				RaytingValue = request.RaytingValue,
				ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString())
			});
		}
	}
}
