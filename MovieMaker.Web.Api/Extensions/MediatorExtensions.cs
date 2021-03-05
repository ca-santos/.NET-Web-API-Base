using Autofac;
using MediatR;
using MediatR.Pipeline;
using MovieMaker.Application;
using MovieMaker.Application.Features.Movies.Commands;
using MovieMaker.Web.Api.Base;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MovieMaker.Web.Api.Extensions
{
    public static class MediatorExtensions
    {

        public static void AddMediator(this ContainerBuilder containerBuilder)
        {

            containerBuilder
                .RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                var assemblies = GetAssemblies().ToArray();
                containerBuilder
                    .RegisterAssemblyTypes(assemblies)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            containerBuilder.RegisterGeneric(typeof(ValidationPipeline<,>)).As(typeof(IPipelineBehavior<,>));
            containerBuilder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            containerBuilder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            containerBuilder.RegisterGeneric(typeof(RequestExceptionActionProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));            
            containerBuilder.RegisterGeneric(typeof(RequestExceptionProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));            

            containerBuilder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).GetTypeInfo().Assembly;            
            yield return typeof(AppModule).GetTypeInfo().Assembly;            
        }

    }

}

