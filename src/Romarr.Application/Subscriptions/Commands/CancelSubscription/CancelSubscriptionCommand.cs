using Romarr.Application.Common.Security.Request;
using Romarr.Application.Common.Security.Roles;

using ErrorOr;

namespace Romarr.Application.Subscriptions.Commands.CancelSubscription;

[Authorize(Roles = Role.Admin)]
public record CancelSubscriptionCommand(Guid UserId, Guid SubscriptionId) : IAuthorizeableRequest<ErrorOr<Success>>;