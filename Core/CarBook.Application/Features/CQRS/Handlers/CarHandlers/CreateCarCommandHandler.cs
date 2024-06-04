using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand comment)
        {
            await _repository.CreateAsync(new Car
            {
                BrandId = comment.BrandId,
                Model = comment.Model,
                CoverImageUrl = comment.CoverImageUrl,
                Km = comment.Km,
                Transmission = comment.Transmission,
                Seat = comment.Seat,
                Luggage = comment.Luggage,
                Fuel = comment.Fuel,
                BigImageUrl = comment.BigImageUrl
            });
        }
    }
}
