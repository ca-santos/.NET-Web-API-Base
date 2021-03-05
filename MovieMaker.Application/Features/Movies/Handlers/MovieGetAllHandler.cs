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
    public class MovieGetAllHandler : IRequestHandler<MovieGetAllQuery, Response<Exception, IQueryable<Movie>>>
    {

        private readonly IMovieRepository _movieRepository;        

        public MovieGetAllHandler(
            IMovieRepository movieRepository
        )
        {
            _movieRepository = movieRepository;
        }

        public async Task<Response<Exception, IQueryable<Movie>>> Handle(MovieGetAllQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_movieRepository.GetAllWithDependencies());
        }

    }
}
