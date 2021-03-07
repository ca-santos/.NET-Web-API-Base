using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieMaker.Web.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MovieMaker.Web.Api.Base;

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

            // Deixei o swaager dispon�vel em todos os ambientes para que os docs da
            // api possam ser expostos de uma forma mais f�cil            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Locadora MovieMaker v1"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            // Roteamento
            app.UseRouting();

            // Autoriza��o
            app.UseAuthorization();

            // Api endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        // Configura��o de alguns servi�os
        public void ConfigureServices(IServiceCollection services)
        {

            // Adiciona os controllers da API
            services.AddControllers();

            // Configs do DI
            services.AddDependencies();
            
            // Configura��o do Automapper
            services.AddAutoMapper();

            // Configura��o do swagger
            services.AddSwagger();

            // Configura��o do MVC
            services.AddMvcConfig();

            // Configura o contexto do banco
            services.AddDbContext(Configuration);

            // Suprime os erros http do tipo 400
            // para poder customizar as exce��es
            services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });

        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            // Configura��o do Mediatr
            containerBuilder.AddMediator();
        }

    }
}
