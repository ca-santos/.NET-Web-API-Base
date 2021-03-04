using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieMaker.Web.Api.Base
{
    /// <summary>
    ///  Classe que representa uma exceção lançada para o client como resposta.
    ///</summary>
    public class ExceptionBase
    {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public List<ValidationFailure> Errors { get; set; }

        public static ExceptionBase New<T>(T exception, int errorCode, List<ValidationFailure> failures = null) where T : Exception
        {
            return new ExceptionBase
            {
                ErrorCode = errorCode,
                ErrorMessage = exception.Message,
                Errors = failures,
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

