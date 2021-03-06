using MediatR;
using MovieMaker.Infra.Shared;
using System;

namespace MovieMaker.Application.Base
{

    // Interface para o uso simplificado da struct Response.
    // Para que o Pipeline da validação funcione corretamente
    public interface IRequestWithResponse<TResponse> : IRequest<Response<Exception, TResponse>>
    {
    }

}
