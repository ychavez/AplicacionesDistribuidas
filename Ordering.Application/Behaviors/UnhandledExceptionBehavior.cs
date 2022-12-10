using MediatR;

namespace Ordering.Application.Behaviors
{
    public class UnhandledExceptionBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {


            try
            {
                return await next();
            }
            catch (Exception ex)
            {

                throw new Exception($"Ocurrio un error en la peticion de {typeof(TRequest)}", ex);
            }
        }
    }
}
