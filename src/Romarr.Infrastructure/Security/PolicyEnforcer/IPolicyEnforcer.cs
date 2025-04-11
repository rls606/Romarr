using Romarr.Application.Common.Security.Request;
using Romarr.Infrastructure.Security.CurrentUserProvider;

using ErrorOr;

namespace Romarr.Infrastructure.Security.PolicyEnforcer;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IAuthorizeableRequest<T> request,
        CurrentUser currentUser,
        string policy);
}