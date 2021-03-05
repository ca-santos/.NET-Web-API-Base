using MediatR;
using MovieMaker.Infra.Shared;
using System;

namespace MovieMaker.Application.Base
{
    public interface IRequestWithResponse<TResponse> : IRequest<Response<Exception, TResponse>>
    {
    }
}
