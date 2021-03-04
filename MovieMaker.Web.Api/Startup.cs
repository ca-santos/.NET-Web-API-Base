using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieMaker.Web.Api.Extensions;

namespace MovieMaker
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieMaker v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // Configura��o de alguns servi�os
        public void ConfigureServices(IServiceCollection services)
        {                        
            services.AddControllers();
            services.AddAutoMapper();
            services.AddSwagger();
            services.AddDependencies(Configuration);
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddMediator();            
        }

    }
}