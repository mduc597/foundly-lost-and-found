using System.Security.Claims;
using Foundly.Sprint1.Data;
using Foundly.Sprint1.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Foundly.Sprint1.Controllers;
public record LoginInput(string Email,string Password);
[ApiController,Route("api/auth")]
public class AuthController(SprintDb db,IPasswordHasher<Student> passwords) : ControllerBase
{
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        if (User.Identity?.IsAuthenticated!=true) return Ok(new {user=(object?)null});
        if (!Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier),out var id)) return Ok(new {user=(object?)null});
        var u=await db.Students.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        return Ok(new {user=u is null?null:new {u.Id,u.Email,u.FullName}});
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginInput input)
    {
        var email=(input.Email??"").Trim().ToLowerInvariant();
        var u=await db.Students.FirstOrDefaultAsync(x=>x.Email==email);
        if (u==null||passwords.VerifyHashedPassword(u,u.PasswordHash,input.Password??"")==PasswordVerificationResult.Failed)
            return Unauthorized(new {message="Email hoặc mật khẩu không đúng."});
        var claims=new[] {new Claim(ClaimTypes.NameIdentifier,u.Id.ToString()),new Claim(ClaimTypes.Name,u.FullName)};
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme)));
        return Ok(new {user=new {u.Id,u.Email,u.FullName}});
    }
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Ok(new {message="Đã đăng xuất."});
    }
}
