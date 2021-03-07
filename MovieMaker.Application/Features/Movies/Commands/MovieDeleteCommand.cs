using FluentValidation;
using MovieMaker.Application.Base;
using MovieMaker.Infra.Shared;

namespace MovieMaker.Application.Features.Movies.Commands
{

    public class MovieDeleteCommand : IRequestWithResponse<AppUnit>, ITransactionScope
    {

        public int Id { get; set; }

    }

    public class MovieDeleteCommandValidator : AbstractValidator<MovieDeleteCommand>
    {

        public MovieDeleteCommandValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty()                
                .WithName("Identificador do filme");

        }

    }

}
