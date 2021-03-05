using MediatR;
using MovieMaker.Application.Features.Movies.Commands;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Movies.Handlers
{
    public class MovieDeleteHandler : IRequestHandler<MovieDeleteCommand, Response<Exception, AppUnit>>
    {

        private readonly IMovieRepository _movieRepository;        

        public MovieDeleteHandler(
            IMovieRepository movieRepository
        )
        {
            _movieRepository = movieRepository;            
        }

        public async Task<Response<Exception, AppUnit>> Handle(MovieDeleteCommand request, CancellationToken cancellationToken)
        {

            var deleteMovieCallback = await _movieRepository.DeleteAsync(request.Id);

            if (deleteMovieCallback.HasError)
                return deleteMovieCallback.Error;

            return AppUnit.Successful;

        }

    }
}
