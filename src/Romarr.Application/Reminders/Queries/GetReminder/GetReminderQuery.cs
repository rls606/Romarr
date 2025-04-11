using Romarr.Application.Common.Security.Permissions;
using Romarr.Application.Common.Security.Policies;
using Romarr.Application.Common.Security.Request;
using Romarr.Domain.Reminders;

using ErrorOr;

namespace Romarr.Application.Reminders.Queries.GetReminder;

[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record GetReminderQuery(Guid UserId, Guid SubscriptionId, Guid ReminderId) : IAuthorizeableRequest<ErrorOr<Reminder>>;