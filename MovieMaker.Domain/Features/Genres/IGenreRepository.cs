using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaker.Domain.Features.Genres
{
    public interface IGenreRepository
    {
        Response<Exception, IQueryable<Genre>> GetAll();

        Task<Response<Exception, Genre>> GetByIdAsync(int id);

        Task<Response<Exception, Genre>> CreateAsync(Genre genre);

        Task<Response<Exception, Genre>> UpdateAsync(Genre genre);

        Task<Response<Exception, AppUnit>> DeleteAsync(int id);

    }
}
