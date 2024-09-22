namespace TaskManagementSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IJwtTokenService _jwtService;

        public LoginController(ApplicationDBContext context, IJwtTokenService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            User user = Authenticate(userLoginDto);

            if (user != null)
            {
                var token = _jwtService.GenerateJwtToken(user);  
                return Ok(new { token });
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterationDto userRegistrationDto)
        {
            if (_context.User.Any(u => u.Username == userRegistrationDto.Username))
            {
                return BadRequest("Username already exists.");
            }

                User user = new User
            {
                Username = userRegistrationDto.Username,
                Password = userRegistrationDto.Password,    
                RoleId = userRegistrationDto.RoleId
            };

            _context.User.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }

        private User Authenticate(UserLoginDto userLoginDto)
        {
            var user = _context.User.FirstOrDefault(u => u.Username == userLoginDto.Username && u.Password == userLoginDto.Password);
            return user;
        }
    }
}
