using MediatR;
using MovieMaker.Application.Features.Genres.Commands;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Infra.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Genres.Handlers
{
    public class GenreDeleteHandler : IRequestHandler<GenreDeleteCommand, Response<Exception, AppUnit>>
    {

        private readonly IGenreRepository _genreRepository;        

        public GenreDeleteHandler(
            IGenreRepository genreRepository
        )
        {
            _genreRepository = genreRepository;            
        }

        public async Task<Response<Exception, AppUnit>> Handle(GenreDeleteCommand request, CancellationToken cancellationToken)
        {

            var deleteGenreCallback = await _genreRepository.DeleteAsync(request.Id);

            if (deleteGenreCallback.HasError)
                return deleteGenreCallback.Error;

            return AppUnit.Successful;

        }

    }
}
