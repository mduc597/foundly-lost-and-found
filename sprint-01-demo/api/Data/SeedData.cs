using Foundly.Sprint1.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Foundly.Sprint1.Data;
public static class SeedData
{
    public static async Task ApplyAsync(SprintDb db, IPasswordHasher<Student> hasher)
    {
        await db.Database.EnsureCreatedAsync(); // Sprint 1 demo database ONLY; production should use migrations.
        if (!await db.Categories.AnyAsync())
        {
            db.Categories.AddRange(new Category { Name="Ví & túi" }, new Category { Name="Giấy tờ" },
                new Category { Name="Thiết bị điện tử" }, new Category { Name="Chìa khóa" },
                new Category { Name="Vật dụng khác" });
            db.Locations.AddRange(new CampusLocation { Name="Thư viện" }, new CampusLocation { Name="Căn tin" },
                new CampusLocation { Name="Tòa A" }, new CampusLocation { Name="Tòa B" },
                new CampusLocation { Name="Sân trường" });
            await db.SaveChangesAsync();
        }
        if (!await db.Students.AnyAsync())
        {
            foreach (var (name,email) in new[] {("Minh", "minh@campus.edu"),("Lan", "lan@campus.edu")})
            {
                var u = new Student { Email=email, FullName=name };
                u.PasswordHash=hasher.HashPassword(u,"Demo12345!");
                db.Students.Add(u);
            }
            await db.SaveChangesAsync();
        }
        if (!await db.Reports.AnyAsync())
        {
            var minh=await db.Students.SingleAsync(x=>x.Email=="minh@campus.edu");
            var lan=await db.Students.SingleAsync(x=>x.Email=="lan@campus.edu");
            var cats=await db.Categories.ToDictionaryAsync(x=>x.Name,x=>x.Id);
            var locs=await db.Locations.ToDictionaryAsync(x=>x.Name,x=>x.Id);
            db.Reports.AddRange(
                new ItemReport { UserId=minh.Id, Type="LOST", ItemName="Ví da màu nâu", Description="Mất ví da màu nâu ở khu vực căn tin, khoảng buổi sáng.", CategoryId=cats["Ví & túi"], LocationId=locs["Căn tin"], EventTime=DateTime.UtcNow.AddHours(-5) },
                new ItemReport { UserId=lan.Id, Type="FOUND", ItemName="Chùm chìa khóa", Description="Nhặt được chùm chìa khóa có móc xanh tại thư viện.", CategoryId=cats["Chìa khóa"], LocationId=locs["Thư viện"], EventTime=DateTime.UtcNow.AddHours(-2) }
            );
            await db.SaveChangesAsync();
        }
    }
}
