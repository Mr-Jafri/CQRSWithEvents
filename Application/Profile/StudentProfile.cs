
namespace Application.Profile;

public static class StudentProfile
{

    public static Student MapCommandToEntity(CreateStudentCommand source)
    {
        return new Student(source.StudentId, source.FirstName, source.LastName, source.Email,
            source.PhoneNumber, source.Address, source.Department, source.GPA);
    }
}
