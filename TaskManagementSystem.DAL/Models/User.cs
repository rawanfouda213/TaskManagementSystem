namespace TaskManagementSystem.DAL.Models;

public class User : BaseModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateOnly RefreshTokenExpiryDate { get; set; }
    [ForeignKey("Role")]
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; } = new Role();
    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();

}
