using Microsoft.AspNetCore.Mvc;
using MovieMaker.Infra.Shared;
using System;
using System.Net;

namespace MovieMaker.Web.Api.Base
{
    public class WebApiBaseController : ControllerBase
    {

        protected IActionResult HandleCommand<TError, TSuccess>
            (Response<TError, TSuccess> result) where TError : Exception
        {
            return result.IsFailure ? HandleFailure(result.Failure) : Ok(result.Success);            
        }

        protected IActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
        {
            HttpStatusCode code;
            ExceptionBase payload;

            if (exceptionToHandle is FluentValidation.ValidationException)
            {
                code = HttpStatusCode.BadRequest;
                payload = ExceptionBase.New(
                    exceptionToHandle,
                    (int)HttpStatusCode.BadRequest,
                    new ValidationFailureMapper().Map((exceptionToHandle as FluentValidation.ValidationException).Errors)
                );
            }
            else
            {
                code = HttpStatusCode.InternalServerError;
                payload = ExceptionBase.New(exceptionToHandle, (int)HttpStatusCode.InternalServerError);
            }

            return StatusCode(code.GetHashCode(), payload);
        }

    }
}
