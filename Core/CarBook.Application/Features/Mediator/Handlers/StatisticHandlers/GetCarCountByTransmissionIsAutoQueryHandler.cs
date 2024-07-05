using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountByTransmissionIsAutoQueryHandler : IRequestHandler<GetCarCountByTransmissionIsAutoQuery, GetCarCountByTransmissionIsAutoQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetCarCountByTransmissionIsAutoQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarCountByTransmissionIsAutoQueryResult> Handle(GetCarCountByTransmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByTransmissionIsAuto();
            return new GetCarCountByTransmissionIsAutoQueryResult
            {
                CarCountByTransmissionIsAuto = value,
            };
        }
    }
}
