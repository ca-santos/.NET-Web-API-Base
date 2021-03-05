using System.Net;

namespace MovieMaker.Infra.Exceptions
{
    public class NotFoundException : AppBaseException
    {
        
        private const HttpStatusCode Code = HttpStatusCode.NotFound;
        private const string BaseMessage = "Registro não encontrado(a).";
        private const string BaseReplaceableMessage = "{entityDisplayName} não possui registros.";
        private const string BaseReplaceableMessageWithId = "{entityDisplayName}({id}) não encontrado(a).";        

        public NotFoundException() : base(Code, BaseMessage)
        {}

        public NotFoundException(string entityDisplayName, int id = -1)
            : base(
                Code, 
                DisplayMessage(BaseMessage, BaseReplaceableMessage, BaseReplaceableMessageWithId, entityDisplayName, id)
            )
        { }

    }
}
