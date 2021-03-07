using FluentValidation;
using MovieMaker.Application.Base;
using MovieMaker.Infra.Shared;

namespace MovieMaker.Application.Features.Genres.Commands
{

    public class GenreDeleteCommand : IRequestWithResponse<AppUnit>, ITransactionScope
    {

        public int Id { get; set; }

    }

    public class GenreDeleteCommandValidator : AbstractValidator<GenreDeleteCommand>
    {

        public GenreDeleteCommandValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty()                
                .WithName("Identificador do gênero");

        }

    }

}
