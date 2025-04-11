using Romarr.Domain.Common;
using Romarr.Domain.Users;

namespace Romarr.Domain.Subscriptions;

public class Subscription : Entity
{
    public SubscriptionType SubscriptionType { get; } = null!;

    public Subscription(SubscriptionType subscriptionType, Guid? id = null)
            : base(id ?? Guid.NewGuid())
    {
        SubscriptionType = subscriptionType;
    }

    public static readonly Subscription Canceled = new(new SubscriptionType("Canceled", -1), Guid.Empty);

    private Subscription()
    {
    }
}