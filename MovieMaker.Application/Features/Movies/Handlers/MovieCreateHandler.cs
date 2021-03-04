using AutoMapper;
using MediatR;
using MovieMaker.Application.Features.Movies.Commands;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Movies.Handlers
{
    public class MovieCreateHandler : IRequestHandler<MovieCreateCommand, Response<Exception, Movie>>
    {

        private readonly IMovieRepository _movieRepository;

        public MovieCreateHandler(
            IMovieRepository movieRepository
        )
        {
            _movieRepository = movieRepository;
        }

        public async Task<Response<Exception, Movie>> Handle(MovieCreateCommand request, CancellationToken cancellationToken)
        {

            var movieMap = Mapper.Map<MovieCreateCommand, Movie>(request);

            var newMovieCallback = await _movieRepository.CreateAsync(movieMap);

            if (newMovieCallback.IsFailure)
                return newMovieCallback.Failure;

            return newMovieCallback.Success;

        }

    }
}
