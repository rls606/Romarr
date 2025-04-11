using Romarr.Application.Authentication.Queries.Login;
using Romarr.Domain.Users;

using ErrorOr;

using MediatR;

namespace Romarr.Application.Tokens.Queries.Generate;

public record GenerateTokenQuery(
    Guid? Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    List<string> Permissions,
    List<string> Roles) : IRequest<ErrorOr<GenerateTokenResult>>;