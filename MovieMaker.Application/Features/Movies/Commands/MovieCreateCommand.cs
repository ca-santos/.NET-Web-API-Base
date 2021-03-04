using FluentValidation;
using MediatR;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Shared;
using System;

namespace MovieMaker.Application.Features.Movies.Commands
{
    public class MovieCreateCommand : IRequest<Response<Exception, Movie>>
    {

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }

        public int GenreId { get; set; }

    }

    public class MovieCreateCommandValidator : AbstractValidator<MovieCreateCommand>
    {

        public MovieCreateCommandValidator()
        {

        }

    }

}
