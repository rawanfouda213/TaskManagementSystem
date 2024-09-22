namespace TaskManagementSystem.PL.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateOnly RefreshTokenExpiryDate { get; set; }
    public virtual ICollection<TasksDto> Tasks { get; set; } = new List<TasksDto>();
}
