
namespace Application.Handlers.Commands;

public class CreateStudentHandler(ILogger<CreateStudentHandler> logger, IDispatcher dispatcher) : ICommandHandler<CreateStudentCommand>
{
    public async Task HandleAsync(CreateStudentCommand command)
    {
        logger.LogInformation(message: "Adding Student information");
        var student = StudentProfile.MapCommandToEntity(command);
        StudentStore.Students.Add(student);
        
        await dispatcher.PublishAsync(@event: new StudentCreatedEvent { 
            FirstName = command.FirstName, 
            LastName = command.LastName,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
            Address = command.Address,
            Department = command.Department,
        });
    }
}
