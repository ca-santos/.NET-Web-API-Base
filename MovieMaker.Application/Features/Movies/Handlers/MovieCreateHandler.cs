using AutoMapper;
using MediatR;
using MovieMaker.Application.Features.Movies.Commands;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Exceptions;
using MovieMaker.Infra.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Application.Features.Movies.Handlers
{
    public class MovieCreateHandler : IRequestHandler<MovieCreateCommand, Response<Exception, Movie>>
    {

        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieCreateHandler(
            IMovieRepository movieRepository,
            IGenreRepository genreRepository
        )
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        public async Task<Response<Exception, Movie>> Handle(MovieCreateCommand request, CancellationToken cancellationToken)
        {

            // Verifica se o genero enviado existe na base
            var genreCallback = await _genreRepository.GetByIdAsync(request.GenreId);
            if (genreCallback.HasError)
                return genreCallback.Error;

            // Checa se o gênero escolhido está inativo
            if (!genreCallback.Success.Active)
                return new InactiveEntityException("Gênero");

            // Faz o mapeamento do command para a entidade
            var movieMap = Mapper.Map<MovieCreateCommand, Movie>(request);

            // Cria o filme
            var newMovieCallback = await _movieRepository.CreateAsync(movieMap);

            // Verifica algum erro
            if (newMovieCallback.HasError)
                return newMovieCallback.Error;

            // Retorna o filme criado
            return newMovieCallback.Success;

        }

    }
}
