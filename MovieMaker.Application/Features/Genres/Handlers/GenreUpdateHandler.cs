using AutoMapper;
using MediatR;
using MovieMaker.Application.Features.Genres.Commands;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Infra.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Genres.Handlers
{
    public class GenreUpdateHandler : IRequestHandler<GenreUpdateCommand, Response<Exception, Genre>>
    {
        
        private readonly IGenreRepository _genreRepository;

        public GenreUpdateHandler(            
            IGenreRepository genreRepository
        )
        {            
            _genreRepository = genreRepository;
        }

        public async Task<Response<Exception, Genre>> Handle(GenreUpdateCommand request, CancellationToken cancellationToken)
        {
            
            var genreCallback = await _genreRepository.GetByIdAsync(request.Id);

            if (genreCallback.HasError)
                return genreCallback.Error;

            var genreMap = Mapper.Map(request, genreCallback.Success);

            var newGenreCallback = await _genreRepository.UpdateAsync(genreMap);

            if (newGenreCallback.HasError)
                return newGenreCallback.Error;

            return newGenreCallback.Success;

        }

    }
}
