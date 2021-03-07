using System.Net;

namespace MovieMaker.Infra.Exceptions
{
    // Exceção para um filme inativo
    public class InactiveEntityException : AppBaseException
    {
        
        private const HttpStatusCode Code = HttpStatusCode.BadRequest;
        private const string BaseMessage = "Existem registros que não estão ativos.";
        private const string BaseReplaceableMessage = "Existem {entityDisplayName} que não estão ativos.";
        private const string BaseReplaceableMessageWithId = "{entityDisplayName} ({id}) não está ativa.";

        public InactiveEntityException() : base(Code, BaseMessage)
        {}

        public InactiveEntityException(string entityName) : base(Code, DisplayMessage(BaseMessage, BaseReplaceableMessage, BaseReplaceableMessageWithId, entityName))
        { }

    }
}
