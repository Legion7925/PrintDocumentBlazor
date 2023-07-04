namespace PrintDocument.Core.Entities;

public class User
{
    public Guid Id { get; set; }

    public required string NameAndFamily { get; set; }

    public string? Email { get; set; }

    public string? MobileNumber { get; set; }

    public required string Username { get; set; }

    public required string PasswordHash { get; set; }
}
