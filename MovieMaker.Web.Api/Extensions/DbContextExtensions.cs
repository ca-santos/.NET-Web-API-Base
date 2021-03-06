using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieMaker.Infra.Data.Context;
using MovieMaker.Infra.Settings;

namespace MovieMaker.Web.Api.Extensions
{
    public static class DbContextExtensions
    {

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            var section = configuration.GetSection("AppSettings");
            var settings = section.Get<AppSettings>();

            services.AddDbContext<MovieMakerDbContext>(options =>
            {
                options.UseSqlServer(settings.ConnectionString);
            });

        }

    }
}
