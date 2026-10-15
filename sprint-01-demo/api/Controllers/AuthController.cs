using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using Foundly.Sprint1.Data;
using Foundly.Sprint1.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
namespace Foundly.Sprint1.Controllers;
public record LoginInput(string Email,string Password);
public record RegisterInput(string? FullName,string? Email,string? Password);
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
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterInput input)
    {
        var fullName=input.FullName?.Trim();
        var email=input.Email?.Trim().ToLowerInvariant();
        var password=input.Password;
        if(string.IsNullOrWhiteSpace(fullName)||fullName.Length>120)
            return BadRequest(new {message="Họ tên là bắt buộc và không được vượt quá 120 ký tự."});
        if(string.IsNullOrWhiteSpace(email)||email.Length>180||!new EmailAddressAttribute().IsValid(email))
            return BadRequest(new {message="Vui lòng nhập email hợp lệ, tối đa 180 ký tự."});
        if(string.IsNullOrWhiteSpace(password)||password.Length<8||password.Length>128)
            return BadRequest(new {message="Mật khẩu phải có từ 8 đến 128 ký tự."});
        if(await db.Students.AnyAsync(x=>x.Email.ToLower()==email))
            return Conflict(new {message="Email này đã được đăng ký."});

        var student=new Student {FullName=fullName,Email=email};
        student.PasswordHash=passwords.HashPassword(student,password);
        db.Students.Add(student);
        try
        {
            await db.SaveChangesAsync();
        }
        catch(DbUpdateException ex) when (ex.InnerException is PostgresException
            { SqlState: PostgresErrorCodes.UniqueViolation, ConstraintName: "IX_Students_Email" })
        {
            return Conflict(new {message="Email này đã được đăng ký."});
        }
        return Ok(new {message="Đăng ký thành công. Vui lòng đăng nhập."});
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
