namespace TaskManagementSystem.BLL.Services;

public class JwtTokenService
{
    private readonly IConfiguration _configuartion;
    public JwtTokenService(IConfiguration _configuartion)
    {
        this._configuartion = _configuartion;
    }
    public string GenerateToken(User user)
    {
        var roleValue = user.Role != null ? user.Role.Name : string.Empty; 
        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),

            new Claim(ClaimTypes.Role, roleValue)
        };
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuartion["Jwt:Key"]));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            _configuartion["Jwt:Issuer"],
            _configuartion["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_configuartion["Jwt:ExpiryMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
