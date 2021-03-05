using AutoMapper;
using MediatR;
using MovieMaker.Application.Features.Rentals.Commands;
using MovieMaker.Domain.Features.Rentals;
using MovieMaker.Infra.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Rentals.Handlers
{
    public class RentalUpdateHandler : IRequestHandler<RentalUpdateCommand, Response<Exception, Rental>>
    {
        
        private readonly IRentalRepository _rentalRepository;

        public RentalUpdateHandler(            
            IRentalRepository rentalRepository
        )
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Response<Exception, Rental>> Handle(RentalUpdateCommand request, CancellationToken cancellationToken)
        {
            
            var rentalCallback = await _rentalRepository.GetByIdAsync(request.Id);

            if (rentalCallback.HasError)
                return rentalCallback.Error;

            var rentalMap = Mapper.Map(request, rentalCallback.Success);

            var newRentalCallback = await _rentalRepository.UpdateAsync(rentalMap);

            if (newRentalCallback.HasError)
                return newRentalCallback.Error;

            return newRentalCallback.Success;

        }

    }
}
