using FluentValidation;
using MovieMaker.Application.Base;
using MovieMaker.Infra.Shared;

namespace MovieMaker.Application.Features.Rentals.Commands
{
    public class RentalFinishCommand : IRequestWithResponse<AppUnit>
    {

        public int RentalId{ get; set; }

    }

    public class RentalFinishCommandValidator : AbstractValidator<RentalFinishCommand>
    {

        public RentalFinishCommandValidator()
        {

            RuleFor(x => x.RentalId)                
                .NotEmpty()
                .WithName("Identificador do aluguel");

        }

    }

}
