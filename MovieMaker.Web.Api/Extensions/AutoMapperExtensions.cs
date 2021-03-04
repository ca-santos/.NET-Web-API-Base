using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace MovieMaker.Web.Api.Extensions
{
    public static class AutoMapperExtensions
    {

        public static void AddAutoMapper(this IServiceCollection services)
        {

            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.AddMaps(typeof(Startup));
                cfg.ValidateInlineMaps = false;
            });

        }

    }
}
