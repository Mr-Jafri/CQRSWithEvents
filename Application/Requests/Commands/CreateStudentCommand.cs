
namespace Application.Requests.Commands;

public record CreateStudentCommand () : ICommand
{
    public required string StudentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public required string Department { get; set; }
    public decimal GPA { get; set; }
}
