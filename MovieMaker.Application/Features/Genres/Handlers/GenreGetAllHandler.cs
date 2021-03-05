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
    public class GenreGetAllHandler : IRequestHandler<GenreGetAllQuery, Response<Exception, IQueryable<Genre>>>
    {

        private readonly IGenreRepository _genreRepository;        

        public GenreGetAllHandler(
            IGenreRepository genreRepository
        )
        {
            _genreRepository = genreRepository;
        }

        public async Task<Response<Exception, IQueryable<Genre>>> Handle(GenreGetAllQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_genreRepository.GetAll());
        }

    }
}
