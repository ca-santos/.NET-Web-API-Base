using AutoMapper;
using MediatR;
using MovieMaker.Application.Features.Rentals.Commands;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Domain.Features.Rentals;
using MovieMaker.Infra.Exceptions;
using MovieMaker.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Rentals.Handlers
{
    public class RentalFinishHandler : IRequestHandler<RentalFinishCommand, Response<Exception, AppUnit>>
    {
        
        private readonly IRentalRepository _rentalRepository;

        public RentalFinishHandler(            
            IRentalRepository rentalRepository
        )
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Response<Exception, AppUnit>> Handle(RentalFinishCommand request, CancellationToken cancellationToken)
        {

            // Retorna a lista virtual dos filmes
            var rentalCallback = await _rentalRepository.GetByIdAsync(request.RentalId);

            // Verifica algum erro
            if (rentalCallback.HasError)
                return rentalCallback.Error;

            var rental = rentalCallback.Success;

            // Finaliza o aluguel
            rental.FinishRental();

            // Atualiza o aluguel
            var newRentalCallback = await _rentalRepository.UpdateAsync(rental);

            // Verifica algum erro 
            if (newRentalCallback.HasError)
                return newRentalCallback.Error;

            // Retorna ok
            return AppUnit.Successful;

        }

    }
}
