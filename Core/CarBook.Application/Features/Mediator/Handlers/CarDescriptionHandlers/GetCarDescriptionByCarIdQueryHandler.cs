﻿using CarBook.Application.Features.Mediator.Queries.CarDescriptionQuery;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;
        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public  async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values =_repository.GetCarDescription(request.Id);
            return new GetCarDescriptionQueryResult
            {
                CarDescriptionId = values.CarDescriptionId,
                CarId = values.CarId,
                Details = values.Details
            };
        }
    }
}
