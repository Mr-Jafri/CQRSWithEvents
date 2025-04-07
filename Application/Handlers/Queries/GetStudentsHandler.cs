namespace Application.Handlers.Queries;

public class GetStudentsHandler(ILogger<GetStudentsHandler> logger) : IQueryHandler<GetStudentsQuery, List<Student>>
{
    public Task<List<Student>> HandleAsync(GetStudentsQuery query)
    {
        logger.LogInformation(message: "Fetching student records.");
        return Task.FromResult(StudentStore.Students);
    }
}
