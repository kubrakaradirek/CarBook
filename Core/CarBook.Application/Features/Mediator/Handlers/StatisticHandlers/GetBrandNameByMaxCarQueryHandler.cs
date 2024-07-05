using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetBrandNameByMaxCarQueryHandler : IRequestHandler<GetBrandNameByMaxCarQuery, GetBrandNameByMaxCarQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetBrandNameByMaxCarQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandNameByMaxCarQueryResult> Handle(GetBrandNameByMaxCarQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBrandNameByMaxCar();
            return new GetBrandNameByMaxCarQueryResult
            {
                 BrandNameByMaxCar = value,
            };
        }
    }
}
