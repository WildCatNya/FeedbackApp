using Feedback.Api.Database;
using Feedback.Api.Database.Entities;
using Feedback.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Buffers.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Feedback.Api.Controllers;

public class AuthController : BaseController
{
    public AuthController(FeedbackContext context) : base(context) { }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        User? user = _context.Users.FirstOrDefault(x => x.Login == loginRequest.Login);

        if (user is null)
            return NotFound("Пользователь не найден");

        if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
            return BadRequest("Пароль введён неверно");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, loginRequest.Login),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role)
        };

        var jwtSecurityToken = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.Now.ToLocalTime().AddMinutes(10),
                signingCredentials: new(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        _context.UserTokens.Add(new UserToken()
        {
            IdUser = user.Id,
            RefreshToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()))
        });

        _context.SaveChanges();

        return Ok(accessToken);
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost("register")]
    public IActionResult Register([FromBody] LoginRequest loginRequest)
    {
        User? user = _context.Users.FirstOrDefault(x => x.Login == loginRequest.Login);

        if (user is not null)
            return BadRequest("Такой пользователь уже существует");

        _context.Users.Add(new User()
        {
            Login = loginRequest.Login,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(loginRequest.Password),
            Role = "User"
        });

        try
        {
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet]
    public IActionResult Logout()
    {
        throw new NotImplementedException();
    }
}