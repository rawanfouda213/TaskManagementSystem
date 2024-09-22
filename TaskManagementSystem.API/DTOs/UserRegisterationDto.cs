namespace TaskManagementSystem.PL.DTOs;

public class UserRegisterationDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
}
