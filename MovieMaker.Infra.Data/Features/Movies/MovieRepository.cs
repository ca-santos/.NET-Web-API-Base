using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Data.Context;
using MovieMaker.Infra.Shared;
using System;
using System.Data.Entity;
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

        public async Task<Response<Exception, Movie>> CreateAsync(Movie movie)
        {

            var newMovie = _context.Add(movie).Entity;

            var saveCallback = await Response.Run(() => _context.SaveChangesAsync());

            if (saveCallback.IsFailure)
                return saveCallback.Failure;

            return newMovie;

        }

        public Response<Exception, IQueryable<Movie>> GetAll()
        {

            var movies = _context.Movies
                .Include(e => e.Genre)
                .AsNoTracking();

            return movies.ToResponse();

        }

    }
}
