using Romarr.Application.Common.Security.Permissions;
using Romarr.Application.Common.Security.Policies;
using Romarr.Application.Common.Security.Request;

using ErrorOr;

namespace Romarr.Application.Reminders.Commands.DeleteReminder;

[Authorize(Permissions = Permission.Reminder.Delete, Policies = Policy.SelfOrAdmin)]
public record DeleteReminderCommand(Guid UserId, Guid SubscriptionId, Guid ReminderId)
    : IAuthorizeableRequest<ErrorOr<Success>>;