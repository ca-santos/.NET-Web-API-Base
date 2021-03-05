using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Data.Context;
using MovieMaker.Infra.Data.Features.Movies;
using MovieMaker.Infra.Settings;

namespace MovieMaker.Web.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {

        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);

            var section = configuration.GetSection("AppSettings");
            var settings = section.Get<AppSettings>();

            services.AddDbContext<MovieMakerDbContext>(options => options.UseSqlServer(settings.ConnectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }

    }
}

