using System.Reflection;

using ErrorOr;
using MediatR;

namespace Romarr.Application.Common.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse>()
        : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        return await next();
    }
}