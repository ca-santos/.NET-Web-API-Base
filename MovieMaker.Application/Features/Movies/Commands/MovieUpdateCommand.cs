using FluentValidation;
using MediatR;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Shared;
using System;

namespace MovieMaker.Application.Features.Movies.Commands
{
    public class MovieUpdateCommand : IRequest<Response<Exception, Movie>>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public int GenreId { get; set; }

    }

    public class MovieUpdateCommandValidator : AbstractValidator<MovieUpdateCommand>
    {

        public MovieUpdateCommandValidator()
        {

        }

    }

}
