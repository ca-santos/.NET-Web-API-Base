using MediatR;
using MovieMaker.Application.Features.Genres.Queries;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Genres.Handlers
{
    public class GenreGetByIdHandler : IRequestHandler<GenreGetByIdQuery, Response<Exception, Genre>>
    {

        private readonly IGenreRepository _genreRepository;        

        public GenreGetByIdHandler(
            IGenreRepository genreRepository
        )
        {
            _genreRepository = genreRepository;
        }

        public async Task<Response<Exception, Genre>> Handle(GenreGetByIdQuery request, CancellationToken cancellationToken)
        {

            var genreCallback = await _genreRepository.GetByIdAsync(request.Id);

            if (genreCallback.HasError)
                return genreCallback.Error;

            return genreCallback.Success;

        }

    }
}
