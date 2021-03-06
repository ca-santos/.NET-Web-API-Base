using System.Net;

namespace MovieMaker.Infra.Exceptions
{
    // Exceção para um filme já alugado
    public class MovieAlreadyRentedException : AppBaseException
    {
        
        private const HttpStatusCode Code = HttpStatusCode.BadRequest;

        public MovieAlreadyRentedException() : base(Code, "Existem Filmes que já estão alugados.")
        {}

    }
}
