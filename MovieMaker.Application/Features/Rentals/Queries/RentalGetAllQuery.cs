using MovieMaker.Application.Base;
using MovieMaker.Domain.Features.Rentals;
using System.Linq;

namespace MovieMaker.Application.Features.Rentals.Queries
{
    public class RentalGetAllQuery : IRequestWithResponse<IQueryable<Rental>>
    {
    }
}
