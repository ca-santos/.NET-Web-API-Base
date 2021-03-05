using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaker.Domain.Features.Movies
{

    public interface IMovieRepository
    {

        Response<Exception, IQueryable<Movie>> GetAll();

        Task<Response<Exception, Movie>> GetById(int id);

        Task<Response<Exception, Movie>> CreateAsync(Movie movie);

        Task<Response<Exception, Movie>> UpdateAsync(Movie movie);

        Task<Response<Exception, AppUnit>> DeleteAsync(int id);

    }

}
