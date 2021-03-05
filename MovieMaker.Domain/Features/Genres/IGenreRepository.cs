using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaker.Domain.Features.Genres
{
    public interface IGenreRepository
    {
        Task<Response<Exception, Genre>> CreateAsync(Genre genre);

        Response<Exception, IQueryable<Genre>> GetAll();

        Task<Response<Exception, Genre>> GetById(int id);

    }
}
