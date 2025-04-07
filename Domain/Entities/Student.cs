namespace Domain.Entities;

public record Student (string StudentId, string FirstName, string LastName, string Email, string PhoneNumber,
    string Address, string Department, decimal GPA);
