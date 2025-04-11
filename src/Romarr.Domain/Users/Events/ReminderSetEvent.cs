using Romarr.Domain.Common;
using Romarr.Domain.Reminders;

namespace Romarr.Domain.Users.Events;

public record ReminderSetEvent(Reminder Reminder) : IDomainEvent;