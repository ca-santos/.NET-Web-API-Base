using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MovieMaker.Web.Api.Base
{

    public class ExceptionBase
    {

        public HttpStatusCode HttpCode { get; set; }

        public int? InternalCode { get; set; }

        public string ErrorMessage { get; set; }

        public List<ValidationFailure> Errors { get; set; }

        public static ExceptionBase GenerateNewError<T>(T exception, HttpStatusCode errorCode, int internalCode = 0, List<ValidationFailure> failures = null) where T : Exception
        {
            var message = exception.Message;

            if (exception is FluentValidation.ValidationException)
                message = "Erros de validação foram encontrados.";            

            return new ExceptionBase
            {
                HttpCode = errorCode,
                ErrorMessage = message,
                Errors = failures,
                InternalCode = internalCode != 0 ? internalCode : (int)errorCode
            };
        }

    }

    public class ValidationFailure
    {
        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorCode { get; set; }
    }

    public class ValidationFailureMapper
    {

        public List<ValidationFailure> Map(IEnumerable<FluentValidation.Results.ValidationFailure> failures)
        {
            return failures.AsQueryable().ProjectTo<ValidationFailure>().ToList();
        }

    }

}

