using MediatR;
using MovieMaker.Application.Features.Movies.Queries;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Movies.Handlers
{
    public class MovieGetByIdHandler : IRequestHandler<MovieGetByIdQuery, Response<Exception, Movie>>
    {

        private readonly IMovieRepository _movieRepository;        

        public MovieGetByIdHandler(
            IMovieRepository movieRepository
        )
        {
            _movieRepository = movieRepository;
        }

        public async Task<Response<Exception, Movie>> Handle(MovieGetByIdQuery request, CancellationToken cancellationToken)
        {

            var movieCallback = await _movieRepository.GetByIdAsync(request.Id);

            if (movieCallback.HasError)
                return movieCallback.Error;

            return movieCallback.Success;

        }

    }
}
