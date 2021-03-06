using System;
using System.Collections.Generic;
using System.Net;

namespace MovieMaker.Web.Api.Base
{
    
    // Classe que permite que exceções personalizadas sejam lançadas    
    public class ExceptionBase
    {

        // Código http
        public HttpStatusCode HttpCode { get; set; }

        // Código interno da aplicação
        public int? InternalCode { get; set; }

        // Mensagem de erro
        public string ErrorMessage { get; set; }

        // Lista de erros de validação do fluent
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

    // Classe que retorna os erros do fluent validation
    public class ValidationFailure
    {
        public string Property { get; set; }

        public string Message { get; set; }

        public string Code { get; set; }
    }

    // Mapeamento para simplificar os retornos do fluent validation para o usuário final
    public class ValidationFailureMapper
    {

        public List<ValidationFailure> Map(IEnumerable<FluentValidation.Results.ValidationFailure> failures)
        {

            List<ValidationFailure> errorList = new List<ValidationFailure>();

            foreach(var fail in failures)
            {
                errorList.Add(new ValidationFailure
                {
                    Property = fail.PropertyName,
                    Code = fail.ErrorCode,
                    Message = fail.ErrorMessage
                });
            }

            return errorList;

        }

    }

}

