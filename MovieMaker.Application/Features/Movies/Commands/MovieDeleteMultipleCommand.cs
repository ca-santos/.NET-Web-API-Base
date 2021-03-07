using FluentValidation;
using MovieMaker.Application.Base;
using MovieMaker.Infra.Shared;
using System.Collections.Generic;

namespace MovieMaker.Application.Features.Movies.Commands
{

    public class MovieDeleteMultipleCommand : IRequestWithResponse<AppUnit>, ITransactionScope
    {

        public List<int> MovieIds { get; set; }

    }

    public class MovieDeleteMultipleCommandValidator : AbstractValidator<MovieDeleteCommand>
    {

        public MovieDeleteMultipleCommandValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty()                
                .WithName("Lista de identificadores dos filmes");

        }

    }

}
