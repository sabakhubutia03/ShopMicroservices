namespace User.Application.DTOs;

public class UserResponseDto
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public DateTime Created { get; set; }
}