using Romarr.Contracts.Common;

namespace Romarr.Contracts.Tokens;

public record TokenResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    string Token);