using Romarr.Domain.Common;

namespace Romarr.Domain.Users.Events;

public record ReminderDismissedEvent(Guid ReminderId) : IDomainEvent;