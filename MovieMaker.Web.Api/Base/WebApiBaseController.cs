using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using MovieMaker.Infra.Exceptions;
using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieMaker.Web.Api.Base
{
    public class WebApiBaseController : ControllerBase
    {

        protected IActionResult HandleCommand<TError, TSuccess>
            (Response<TError, TSuccess> result) where TError : Exception
        {
            return result.HasError ? HandleErrors(result.Error) : Ok(result.Success);
        }

        protected IActionResult HandleQueryable<TFrom, TResult>(Response<Exception, IQueryable<TFrom>> result)
        {
            if (result.HasError)
                return HandleErrors(result.Error);

            return Ok(result.Success.ProjectTo<TResult>());
        }

        protected IActionResult HandleQuery<TFrom, TResult>(Response<Exception, TFrom> result)
        {
            if (result.HasError)
                return HandleErrors(result.Error);

            return Ok(Mapper.Map<TFrom, TResult>(result.Success));
        }

        protected IActionResult HandleErrors<T>(T exceptionToHandle) where T : Exception
        {

            HttpStatusCode code;
            ExceptionBase payload;
            int internalError = 0;

            if (exceptionToHandle is FluentValidation.ValidationException)
            {

                code = HttpStatusCode.BadRequest;
                var errors = new ValidationFailureMapper().Map((exceptionToHandle as FluentValidation.ValidationException).Errors);

                payload = ExceptionBase.GenerateNewError(exceptionToHandle, code, internalError, errors);

            }
            else if (exceptionToHandle is AppBaseException)
            {

                var ex = (exceptionToHandle as AppBaseException);
                code = ex.StatusCode;

                payload = ExceptionBase.GenerateNewError(ex, code);

            }
            else
            {

                code = HttpStatusCode.InternalServerError;

                payload = ExceptionBase.GenerateNewError(exceptionToHandle, HttpStatusCode.InternalServerError);

            }

            return StatusCode(code.GetHashCode(), payload);

        }

    }
}
