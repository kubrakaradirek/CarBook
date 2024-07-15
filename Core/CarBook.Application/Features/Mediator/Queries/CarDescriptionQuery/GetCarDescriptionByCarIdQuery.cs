﻿using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarDescriptionQuery
{
    public class GetCarDescriptionByCarIdQuery:IRequest<GetCarDescriptionQueryResult>
    {
        public int Id { get; set; }
        public GetCarDescriptionByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
