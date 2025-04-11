using Romarr.Domain.Common;

namespace Romarr.Domain.Users.Events;

public record SubscriptionCanceledEvent(User User, Guid SubscriptionId) : IDomainEvent;