using FluentValidation;
using MovieMaker.Application.Base;
using MovieMaker.Domain.Features.Genres;
using System;

namespace MovieMaker.Application.Features.Genres.Commands
{
    public class GenreCreateCommand : IRequestWithResponse<Genre>, ITransactionScope
    {

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }

    }

    public class GenreCreateCommandValidator : AbstractValidator<GenreCreateCommand>
    {

        public GenreCreateCommandValidator()
        {

            RuleFor(x => x.Name)                
                .NotEmpty()
                .MaximumLength(100)
                .WithName("Nome do gênero");

        }

    }

}
