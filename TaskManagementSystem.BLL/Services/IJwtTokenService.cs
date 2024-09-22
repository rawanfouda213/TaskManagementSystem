namespace TaskManagementSystem.BLL.Services;

public interface IJwtTokenService
{
    string GenerateJwtToken(User user);
}
