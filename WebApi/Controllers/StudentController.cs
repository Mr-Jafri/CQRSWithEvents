
namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IDispatcher dispatcher, ILogger<StudentController> logger) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
    {
        logger.LogInformation(message: "Request received to create student.");
        await dispatcher.SendAsync(command);
        logger.LogInformation(message: "Student created successfully.");

        return Ok("Student created successfully");
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await dispatcher.QueryAsync<GetStudentsQuery, List<Student>>(new GetStudentsQuery { });
        return Ok(result);
    }
}
