using MediatR;
using MovieMaker.Application.Features.Rentals.Queries;
using MovieMaker.Domain.Features.Rentals;
using MovieMaker.Infra.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Rentals.Handlers
{
    public class RentalGetByIdHandler : IRequestHandler<RentalGetByIdQuery, Response<Exception, Rental>>
    {

        private readonly IRentalRepository _rentalRepository;        

        public RentalGetByIdHandler(
            IRentalRepository rentalRepository
        )
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Response<Exception, Rental>> Handle(RentalGetByIdQuery request, CancellationToken cancellationToken)
        {

            var rentalCallback = await _rentalRepository.GetByIdAsync(request.Id);

            if (rentalCallback.HasError)
                return rentalCallback.Error;

            return rentalCallback.Success;

        }

    }
}
