using FluentValidation;
using MovieMaker.Application.Base;
using MovieMaker.Domain.Features.Rentals;
using System.Collections.Generic;

namespace MovieMaker.Application.Features.Rentals.Commands
{
    public class RentalUpdateCommand : IRequestWithResponse<Rental>
    {

        public int Id { get; set; }

        public List<int> MovieIds { get; set; }

    }

    public class RentalUpdateCommandValidator : AbstractValidator<RentalUpdateCommand>
    {

        public RentalUpdateCommandValidator()
        {

        }

    }

}
