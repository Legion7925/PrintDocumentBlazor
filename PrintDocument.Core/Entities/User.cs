namespace PrintDocument.Core.Entities;

public class User
{
    public int Id { get; set; }

    public string NameAndFamily { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public  string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;
}
