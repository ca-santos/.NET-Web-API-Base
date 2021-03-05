using FluentValidation;
using MediatR;
using MovieMaker.Application.Base;
using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieMaker.Web.Api.Base
{

    // Baseado em: https://github.com/jbogard/MediatR/wiki/Behaviors

    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, Response<Exception, TResponse>>
        where TRequest : IRequestWithResponse<TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidationPipeline(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public async Task<Response<Exception, TResponse>> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Response<Exception, TResponse>> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(Response => Response.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                return new ValidationException(failures);
            }

            return await next();
        }
    }

}
