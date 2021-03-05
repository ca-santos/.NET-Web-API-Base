using Microsoft.EntityFrameworkCore;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Infra.Data.Context;
using MovieMaker.Infra.Exceptions;
using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaker.Infra.Data.Features.Movies
{
    public class GenreRepository : IGenreRepository
    {

        private readonly MovieMakerDbContext _context;

        public GenreRepository(MovieMakerDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Exception, Genre>> CreateAsync(Genre genre)
        {

            var newGenre = _context.Add(genre).Entity;

            var saveCallback = await Response.Run(() => _context.SaveChangesAsync());

            if (saveCallback.HasError)
                return saveCallback.Error;

            return newGenre;

        }

        public Response<Exception, IQueryable<Genre>> GetAll()
        {

            var genres = _context.Genres
                .AsNoTracking();

            return genres.ToResponse();

        }

        public async Task<Response<Exception, Genre>> GetById(int id)
        {
            var genre = await Response.Run(() => _context.Genres.FirstOrDefaultAsync(x => x.Id == id));

            if (genre.HasError)
                return genre.Error;

            if(genre.Success == null)
                return new NotFoundException("Gênero", id);

            return genre.Success;
        }

    }
}
