using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Domain.Features.Rentals;
using MovieMaker.Infra.Data.Context;
using MovieMaker.Infra.Data.Features.Movies;
using MovieMaker.Infra.Data.Features.Rentals;
using MovieMaker.Infra.Settings;
using System;

namespace MovieMaker.Web.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {

        public static void AddDependencies(this IServiceCollection services)
        {
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
        }

    }
}

