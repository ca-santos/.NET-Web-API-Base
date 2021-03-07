using AutoMapper;
using MediatR;
using MovieMaker.Application.Base;
using MovieMaker.Application.Features.Genres.Commands;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Infra.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Genres.Handlers
{
    public class GenreCreateHandler 
        : IRequestHandler<GenreCreateCommand, Response<Exception, Genre>>
    {
        
        private readonly IGenreRepository _genreRepository;

        public GenreCreateHandler(            
            IGenreRepository genreRepository
        )
        {            
            _genreRepository = genreRepository;
        }

        public async Task<Response<Exception, Genre>> Handle(GenreCreateCommand request, CancellationToken cancellationToken)
        {

            var genreMap = Mapper.Map<GenreCreateCommand, Genre>(request);

            var newGenreCallback = await _genreRepository.CreateAsync(genreMap);

            if (newGenreCallback.HasError)
                return newGenreCallback.Error;

            return newGenreCallback.Success;

        }

    }
}
