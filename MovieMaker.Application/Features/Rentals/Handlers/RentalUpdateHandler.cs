using AutoMapper;
using MediatR;
using MovieMaker.Application.Features.Rentals.Commands;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Domain.Features.Rentals;
using MovieMaker.Infra.Exceptions;
using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Rentals.Handlers
{
    public class RentalUpdateHandler : IRequestHandler<RentalUpdateCommand, Response<Exception, Rental>>
    {
        
        private readonly IRentalRepository _rentalRepository;
        private readonly IMovieRepository _movieRepository;

        public RentalUpdateHandler(            
            IRentalRepository rentalRepository,
            IMovieRepository movieRepository
        )
        {
            _rentalRepository = rentalRepository;
            _movieRepository = movieRepository;
        }

        public async Task<Response<Exception, Rental>> Handle(RentalUpdateCommand request, CancellationToken cancellationToken)
        {

            // Busca o aluguel informado
            var rentalCallback = await _rentalRepository.GetByIdAsync(request.Id);

            // Verifica algum erro
            if (rentalCallback.HasError)
                return rentalCallback.Error;

            var rental = rentalCallback.Success;

            // Retorna a lista virtual dos filmes
            var moviesCallback = _movieRepository.GetAll();

            // Verifica algum erro
            if (moviesCallback.HasError)
                return moviesCallback.Error;

            // Filtra a lista dos filmes
            var movies = moviesCallback.Success
                .Where((x => request.MovieIds.Contains(x.Id))).ToList();

            // Retorna erro caso não existam filmes
            if (!movies.Any())
                return new NotFoundException("Filme");

            // Retorna erro caso algum filme não esteja ativo
            if (movies.Any(x => x.Active == false))
                return new InactiveEntityException("Filmes");

            // Retorna erro caso algum filme já esteja alugado
            // e não pertença a esse aluguel
            if (movies.Any(x => x.IsRented() && x.ActiveRentalId != rental.Id))
                return new MovieAlreadyRentedException();

            // Faz o map do commando
            var rentalMap = Mapper.Map(request, rental);

            // Adiciona os filmes encontrados no aluguel
            rentalMap.AddMovies(movies);

            // Atualiza o aluguel
            var updateRentalCallback = await _rentalRepository.UpdateAsync(rentalMap);

            // Verifica algum erro 
            if (updateRentalCallback.HasError)
                return updateRentalCallback.Error;

            // Retorna o aluguel
            return updateRentalCallback.Success;

        }

    }
}
