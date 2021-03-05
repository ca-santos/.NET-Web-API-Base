using FluentValidation;
using MediatR;
using MovieMaker.Application.Base;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Shared;
using System;

namespace MovieMaker.Application.Features.Movies.Commands
{
    public class MovieCreateCommand : IRequestWithResponse<Movie>
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

            RuleFor(x => x.Name)                
                .NotEmpty()
                .MaximumLength(200)
                .WithName("Nome do filme");

            RuleFor(x => x.GenreId)                
                .NotEmpty()
                .WithName("Identificador do gênero");

        }

    }

}
