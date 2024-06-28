using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.Config;
using Project.Context;
using Project.DTOs.Authentication;

namespace Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{

    private readonly ApbdProjectContext _context;
    private readonly IConfiguration _configuration;

    public AuthenticationController(ApbdProjectContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(AuthenticationRequest loginRequest)
    {
        var users = _context.Users.ToList();
        foreach (var user1 in users)
        {
            Console.WriteLine(user1.Login);
        }
        var user = _context.Users.FirstOrDefault(u => u.Login == loginRequest.Login);
        
        if (user == null)
        {
            return NotFound("User not found");
        }
        
        if (loginRequest.Password != user.Password)
        {
            return Unauthorized();
        }

        var roles = user.Roles.Split(',');
        var userClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Login),
        };

        foreach (var role in roles)
        {
            userClaims.Add(new Claim(ClaimTypes.Role, role.Trim()));
        }
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: credentials
        );
        _context.SaveChanges();
        return Ok(new
        {
            accessToken = new JwtSecurityTokenHandler().WriteToken(token),
        });
    }
}
