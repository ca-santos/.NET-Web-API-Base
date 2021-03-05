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

        public Response<Exception, IQueryable<Genre>> GetAll()
        {

            var movies = _context.Genres                
                .AsNoTracking();

            return movies.ToResponse();

        }

        public async Task<Response<Exception, Genre>> GetByIdAsync(int id)
        {

            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (genre == null)
                return new NotFoundException("Gênero", id);

            return genre;

        }

        public async Task<Response<Exception, Genre>> CreateAsync(Genre genre)
        {

            var newGenre = _context.Genres.Add(genre).Entity;

            var saveCallback = await Response.Run(() => _context.SaveChangesAsync());

            if (saveCallback.HasError)
                return saveCallback.Error;

            return newGenre;

        }

        public async Task<Response<Exception, Genre>> UpdateAsync(Genre genre)
        {

            _context.Genres.Update(genre);

            var saveCallback = await Response.Run(() => _context.SaveChangesAsync());

            if (saveCallback.HasError)
                return saveCallback.Error;

            return genre;

        }

        public async Task<Response<Exception, AppUnit>> DeleteAsync(int id)
        {

            var genreCallback = await GetByIdAsync(id);

            if (genreCallback.HasError)
                return genreCallback.Error;

            var deleteCallback = await Response.Run(() =>
            {
                _context.Genres.Remove(genreCallback.Success);
                return _context.SaveChangesAsync();
            });

            if (deleteCallback.HasError)
                return deleteCallback.Error;

            return AppUnit.Successful;

        }

    }
}
