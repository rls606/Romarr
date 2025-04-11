using Romarr.Domain.Common;

namespace Romarr.Domain.Users.Events;

public record ReminderDeletedEvent(Guid ReminderId) : IDomainEvent;