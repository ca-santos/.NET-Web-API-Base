using MovieMaker.Application.Base;
using MovieMaker.Domain.Features.Rentals;

namespace MovieMaker.Application.Features.Rentals.Queries
{

    public class RentalGetByIdQuery : IRequestWithResponse<Rental>
    {

        public int Id { get; set; }

    }

}
