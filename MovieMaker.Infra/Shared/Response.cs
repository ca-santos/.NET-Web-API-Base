using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaker.Infra.Shared
{

    public struct Response<TError, TSuccess> where TError : Exception
    {

        public TError Error { get; internal set; }
        public TSuccess Success { get; internal set; }

        public bool HasError { get; }
        public bool IsSuccess => !HasError;

        internal Response(TError failure)
        {
            HasError = true;
            Error = failure;
            Success = default;
        }

        internal Response(TSuccess success)
        {
            HasError = false;
            Error = default;
            Success = success;
        }

        public static implicit operator Response<TError, TSuccess>(TError failure)
            => new(failure);

        public static implicit operator Response<TError, TSuccess>(TSuccess success)
            => new(success);

        public static Response<TError, TSuccess> Of(TSuccess obj) => obj;

        public static Response<TError, TSuccess> Of(TError obj) => obj;

    }

    public static class Response
    {

        public static async Task<Response<Exception, TSuccess>> Run<TSuccess>(Func<Task<TSuccess>> function)
        {

            try
            {
                return await function();
            }
            catch(Exception exception)
            {
                return exception;
            }

        }

        public static Response<Exception, TSuccess> Run<TSuccess>(this Func<TSuccess> function)
        {

            try
            {
                return function();
            }
            catch (Exception exception)
            {
                return exception;
            }

        }

        public static Response<Exception, IQueryable<TSuccess>> ToResponse<TSuccess>(this IEnumerable<TSuccess> from)
        {
            return Run(() => from.AsQueryable());
        }

    }

}
