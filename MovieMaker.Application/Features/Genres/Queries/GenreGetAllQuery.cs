using MovieMaker.Application.Base;
using MovieMaker.Domain.Features.Genres;
using System.Linq;

namespace MovieMaker.Application.Features.Genres.Queries
{
    public class GenreGetAllQuery : IRequestWithResponse<IQueryable<Genre>>
    {
    }
}
