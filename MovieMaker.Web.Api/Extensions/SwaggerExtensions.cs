using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MovieMaker.Web.Api.Extensions
{
    public static class SwaggerExtensions
    {

        public static void AddSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MovieMaker",
                    Version = "v1"
                });
            });

        }

    }
}
