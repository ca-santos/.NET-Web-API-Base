using System;
using System.Net;

namespace MovieMaker.Infra.Exceptions
{
    public abstract class AppBaseException : Exception
    { 

        public AppBaseException(HttpStatusCode httpCode, string message) : base(message)
        {
            StatusCode = httpCode;
        }

        public HttpStatusCode StatusCode { get; }

        // Manipula a mensagem recebida para fornecer um 
        // retorno mais amigável
        public static string DisplayMessage(
            string baseMessage, 
            string baseReplaceableMessage, 
            string baseReplaceableMessageWithId,            
            string entityDisplayName = null, 
            int id = -1
        )
        {
            
            if(entityDisplayName != null && id > -1)
            {
                return baseReplaceableMessageWithId
                    .Replace("{entityDisplayName}", entityDisplayName)
                    .Replace("{id}", id.ToString());
            }
            else if(entityDisplayName != null)
            {
                return baseReplaceableMessage.Replace("{entityDisplayName}", entityDisplayName);
            }

            return baseMessage;
            
        }

    }
}
