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
    public class RentalGetByCustomerCPFHandler : IRequestHandler<RentalGetByCustomerCpfQuery, Response<Exception, IQueryable<Rental>>>
    {

        private readonly IRentalRepository _rentalRepository;        

        public RentalGetByCustomerCPFHandler(
            IRentalRepository rentalRepository
        )
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Response<Exception, IQueryable<Rental>>> Handle(RentalGetByCustomerCpfQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_rentalRepository.GetByCustomerCPF(request.Cpf));
        }

    }
}
