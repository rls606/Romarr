using Romarr.Application.Common.Security.Permissions;
using Romarr.Application.Common.Security.Policies;
using Romarr.Application.Common.Security.Request;
using Romarr.Application.Subscriptions.Common;
using Romarr.Domain.Users;

using ErrorOr;

namespace Romarr.Application.Subscriptions.Commands.CreateSubscription;

[Authorize(Permissions = Permission.Subscription.Create, Policies = Policy.SelfOrAdmin)]
public record CreateSubscriptionCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType)
    : IAuthorizeableRequest<ErrorOr<SubscriptionResult>>;