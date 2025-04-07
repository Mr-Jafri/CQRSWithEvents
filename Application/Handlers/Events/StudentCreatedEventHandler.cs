namespace Application.Handlers.Events;

public class StudentCreatedEventHandler(ILogger<StudentCreatedEventHandler> logger) : IEventHandler<StudentCreatedEvent>
{
    public Task HandleAsync(StudentCreatedEvent @event)
    {
        logger.LogInformation(message: $"[Event] StudentCreated: Sending email for using broker service to student: {@event.FirstName} {@event.LastName}");
        logger.LogInformation(message: "[Event] Will configure the broker service in next step.");

        return Task.CompletedTask;
    }
}
