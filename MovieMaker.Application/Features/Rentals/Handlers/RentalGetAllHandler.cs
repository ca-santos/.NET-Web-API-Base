using MediatR;
using MovieMaker.Application.Features.Rentals.Queries;
using MovieMaker.Domain.Features.Rentals;
using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Rentals.Handlers
{
    public class RentalGetAllHandler : IRequestHandler<RentalGetAllQuery, Response<Exception, IQueryable<Rental>>>
    {

        private readonly IRentalRepository _rentalRepository;        

        public RentalGetAllHandler(
            IRentalRepository rentalRepository
        )
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Response<Exception, IQueryable<Rental>>> Handle(RentalGetAllQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_rentalRepository.GetAll());
        }

    }
}
