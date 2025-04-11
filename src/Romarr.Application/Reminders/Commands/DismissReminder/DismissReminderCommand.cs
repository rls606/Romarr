using Romarr.Application.Common.Security.Permissions;
using Romarr.Application.Common.Security.Policies;
using Romarr.Application.Common.Security.Request;

using ErrorOr;

namespace Romarr.Application.Reminders.Commands.DismissReminder;

[Authorize(Permissions = Permission.Reminder.Dismiss, Policies = Policy.SelfOrAdmin)]
public record DismissReminderCommand(Guid UserId, Guid SubscriptionId, Guid ReminderId)
    : IAuthorizeableRequest<ErrorOr<Success>>;