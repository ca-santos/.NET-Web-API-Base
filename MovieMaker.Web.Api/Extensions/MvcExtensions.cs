using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MovieMaker.Application;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MovieMaker.Web.Api.Extensions
{
    public static class MvcExtensions
    {

        public static void AddMvcConfig(this IServiceCollection services)
        {

            services.AddMvc()
                .AddNewtonsoftJson(opt =>
                 {
                     opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                     opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                     opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                     opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                     opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                     opt.SerializerSettings.Formatting = Formatting.None;
                 })
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AppModule>());

        }

    }
}
