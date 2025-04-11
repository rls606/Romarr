using Romarr.Application.Common.Security.Permissions;
using Romarr.Application.Common.Security.Policies;
using Romarr.Application.Common.Security.Request;
using Romarr.Domain.Reminders;

using ErrorOr;

namespace Romarr.Application.Reminders.Queries.ListReminders;

[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record ListRemindersQuery(Guid UserId, Guid SubscriptionId) : IAuthorizeableRequest<ErrorOr<List<Reminder>>>;