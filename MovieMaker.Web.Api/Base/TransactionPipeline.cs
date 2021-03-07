using MediatR;
using MovieMaker.Application.Base;
using MovieMaker.Infra.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace MovieMaker.Web.Api.Base
{

    // Pipeline de transações.
    // Identifica os commands que devem usar transações
    // através da interface ITransactionScope
    // Baseado em: https://radekmaziarka.pl/2018/01/04/mediatr-autofac-shared-transaction-on-command-level/
    public class TransactionPipeline<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, Response<Exception, TResponse>> 
        where TRequest : ITransactionScope
    {

        public async Task<Response<Exception, TResponse>> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Response<Exception, TResponse>> next)
        {

            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            using (var transaction = new TransactionScope(
                TransactionScopeOption.Required, transactionOptions,
                TransactionScopeAsyncFlowOption.Enabled
            ))
            {
                // chama o handler
                var response = await next();

                // caso a resposta do handler
                // falhe a transação é cancelada
                if (response.HasError)
                {
                    transaction.Dispose();
                    return response.Error;
                }

                // Completa a transação
                transaction.Complete();

                return response;
            }

        }

    }
}
