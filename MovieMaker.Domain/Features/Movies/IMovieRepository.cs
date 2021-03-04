using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaker.Domain.Features.Movies
{

    public interface IMovieRepository
    {

        Task<Response<Exception, Movie>> CreateAsync(Movie movie);

        Response<Exception, IQueryable<Movie>> GetAll();

    }

}
