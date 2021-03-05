using System.Net;

namespace MovieMaker.Infra.Exceptions
{
    public class MovieInactiveException : AppBaseException
    {
        
        private const HttpStatusCode Code = HttpStatusCode.BadRequest;

        public MovieInactiveException() : base(Code, "Existem Filmes que não estão ativos.")
        {}

    }
}
