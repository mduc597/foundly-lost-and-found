using System.Security.Claims;
using Foundly.Sprint1.Data;
using Foundly.Sprint1.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<SprintDb>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Main")));
builder.Services.AddScoped<IPasswordHasher<Student>, PasswordHasher<Student>>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o =>
{
    o.Cookie.Name="foundly.sprint1.session";
    o.Cookie.HttpOnly=true;
    o.Cookie.SameSite=SameSiteMode.Strict;
    o.Cookie.SecurePolicy=CookieSecurePolicy.SameAsRequest;
    o.Events.OnRedirectToLogin=ctx => {ctx.Response.StatusCode=401;return Task.CompletedTask;};
    o.Events.OnRedirectToAccessDenied=ctx => {ctx.Response.StatusCode=403;return Task.CompletedTask;};
});
builder.Services.AddAuthorization();
var app = builder.Build();
app.Use(async (ctx,next)=>
{
    // Demo CSRF mitigation: only localhost frontends may submit browser mutations.
    if (!HttpMethods.IsGet(ctx.Request.Method) && !HttpMethods.IsHead(ctx.Request.Method)
        && ctx.Request.Headers.TryGetValue("Origin", out var origin))
    {
        if (!Uri.TryCreate(origin.ToString(),UriKind.Absolute,out var u)
            || (u.Host!="localhost" && u.Host!="127.0.0.1")
            || (u.Port!=5181 && u.Port!=8081))
        {ctx.Response.StatusCode=403;return;}
    }
    await next();
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/api/health", () => Results.Ok(new {status="ok",sprint=1}));
using (var scope=app.Services.CreateScope())
    await SeedData.ApplyAsync(scope.ServiceProvider.GetRequiredService<SprintDb>(),
        scope.ServiceProvider.GetRequiredService<IPasswordHasher<Student>>());
app.Run();
