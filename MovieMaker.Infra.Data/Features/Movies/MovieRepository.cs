using Microsoft.EntityFrameworkCore;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Data.Context;
using MovieMaker.Infra.Exceptions;
using MovieMaker.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaker.Infra.Data.Features.Movies
{
    public class MovieRepository : IMovieRepository
    {

        private readonly MovieMakerDbContext _context;

        public MovieRepository(MovieMakerDbContext context)
        {
            _context = context;
        }

        public Response<Exception, IQueryable<Movie>> GetAll()
        {

            var movies = _context.Movies;

            return movies.ToResponse();

        }

        public Response<Exception, IQueryable<Movie>> GetAllWithDependencies()
        {

            var movies = _context.Movies
                .Include(e => e.Genre)
                .AsNoTracking();

            return movies.ToResponse();

        }

        public async Task<Response<Exception, Movie>> GetByIdAsync(int id)
        {

            var movie = await _context.Movies
                .Include(e => e.Genre)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
                return new NotFoundException("Filme", id);

            return movie;

        }

        public async Task<Response<Exception, Movie>> CreateAsync(Movie movie)
        {

            var newMovie = _context.Add(movie).Entity;

            var saveCallback = await Response.Run(() => _context.SaveChangesAsync());

            if (saveCallback.HasError)
                return saveCallback.Error;

            return newMovie;

        }

        public async Task<Response<Exception, Movie>> UpdateAsync(Movie movie)
        {

            _context.Update(movie);

            var saveCallback = await Response.Run(() => _context.SaveChangesAsync());

            if (saveCallback.HasError)
                return saveCallback.Error;

            return movie;

        }

        public async Task<Response<Exception, AppUnit>> DeleteAsync(int id)
        {

            var movieCallback = await GetByIdAsync(id);

            if (movieCallback.HasError)
                return movieCallback.Error;

            var deleteCallback = await Response.Run(() =>
            {
                _context.Remove(movieCallback.Success);
                return _context.SaveChangesAsync();
            });

            if (deleteCallback.HasError)
                return deleteCallback.Error;

            return AppUnit.Successful;

        }
        
        public async Task<Response<Exception, AppUnit>> DeleteMultipleAsync(List<int> ids)
        {

            var deleteCallback = await Response.Run(() =>
            {
                _context.RemoveRange(_context.Movies.Where(x => ids.Contains(x.Id)));
                return _context.SaveChangesAsync();
            });

            if (deleteCallback.HasError)
                return deleteCallback.Error;

            return AppUnit.Successful;

        }

    }
}
