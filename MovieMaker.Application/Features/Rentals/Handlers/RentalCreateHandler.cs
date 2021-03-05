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
    public class RentalCreateHandler : IRequestHandler<RentalCreateCommand, Response<Exception, Rental>>
    {
        
        private readonly IRentalRepository _rentalRepository;
        private readonly IMovieRepository _movieRepository;

        public RentalCreateHandler(            
            IRentalRepository rentalRepository,
            IMovieRepository movieRepository
        )
        {
            _rentalRepository = rentalRepository;
            _movieRepository = movieRepository;
        }

        public async Task<Response<Exception, Rental>> Handle(RentalCreateCommand request, CancellationToken cancellationToken)
        {

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
                return new MovieInactiveException();

            // Retorna erro caso algum filme já esteja alugado
            if (movies.Any(x => x.IsRented()))
                return new MovieAlreadyRentedException();

            // Faz o map do commando
            var rentalMap = Mapper.Map<RentalCreateCommand, Rental>(request);

            // Adiciona os filmes encontrados no aluguel
            rentalMap.AddMovies(movies);

            // Cria o aluguel
            var newRentalCallback = await _rentalRepository.CreateAsync(rentalMap);

            // Verifica algum erro 
            if (newRentalCallback.HasError)
                return newRentalCallback.Error;

            // Retorna o aluguel
            return newRentalCallback.Success;

        }

    }
}
