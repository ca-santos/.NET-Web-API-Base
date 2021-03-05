using MovieMaker.Application.Base;
using MovieMaker.Domain.Features.Genres;

namespace MovieMaker.Application.Features.Genres.Queries
{

    public class GenreGetByIdQuery : IRequestWithResponse<Genre>
    {

        public int Id { get; set; }

    }

}
