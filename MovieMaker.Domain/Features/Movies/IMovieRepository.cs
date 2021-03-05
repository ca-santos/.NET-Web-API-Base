using MovieMaker.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaker.Domain.Features.Movies
{

    public interface IMovieRepository
    {

        Response<Exception, IQueryable<Movie>> GetAll();

        Response<Exception, IQueryable<Movie>> GetAllWithDependencies();

        Task<Response<Exception, Movie>> GetByIdAsync(int id);

        Task<Response<Exception, Movie>> CreateAsync(Movie movie);

        Task<Response<Exception, Movie>> UpdateAsync(Movie movie);

        Task<Response<Exception, AppUnit>> DeleteAsync(int id);

        Task<Response<Exception, AppUnit>> DeleteMultipleAsync(List<int> ids);

    }

}
