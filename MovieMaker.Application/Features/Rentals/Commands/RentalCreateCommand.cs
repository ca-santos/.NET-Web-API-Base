using FluentValidation;
using MovieMaker.Application.Base;
using MovieMaker.Domain.Features.Rentals;
using System;
using System.Collections.Generic;

namespace MovieMaker.Application.Features.Rentals.Commands
{
    public class RentalCreateCommand : IRequestWithResponse<Rental>
    {

        public IEnumerable<int> MovieIds { get; set; }

        public DateTime RentedAt { get; set; }

        public string CustomerCPF { get; set; }

    }

    public class RentalCreateCommandValidator : AbstractValidator<RentalCreateCommand>
    {

        public RentalCreateCommandValidator()
        {

            RuleFor(x => x.CustomerCPF)                
                .NotEmpty()
                .MaximumLength(14)
                .WithName("CPF do cliente");

        }

    }

}
