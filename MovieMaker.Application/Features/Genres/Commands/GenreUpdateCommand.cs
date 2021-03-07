using FluentValidation;
using MovieMaker.Application.Base;
using MovieMaker.Domain.Features.Genres;

namespace MovieMaker.Application.Features.Genres.Commands
{
    public class GenreUpdateCommand : IRequestWithResponse<Genre>, ITransactionScope
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

    }

    public class GenreUpdateCommandValidator : AbstractValidator<GenreUpdateCommand>
    {

        public GenreUpdateCommandValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithName("Nome do gênero");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithName("Identificador do gênero");

        }

    }

}
