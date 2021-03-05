using FluentValidation;
using MovieMaker.Application.Base;
using MovieMaker.Domain.Features.Movies;

namespace MovieMaker.Application.Features.Movies.Commands
{
    public class MovieUpdateCommand : IRequestWithResponse<Movie>
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
