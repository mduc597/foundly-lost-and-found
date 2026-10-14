using System.Security.Claims;
using Foundly.Sprint1.Data;
using Foundly.Sprint1.Domain;
using Foundly.Sprint1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Foundly.Sprint1.Controllers;
public record ReportInput(string Type,string ItemName,string Description,int CategoryId,int LocationId,DateTime EventTime);
[ApiController,Authorize,Route("api/reports")]
public class ReportsWriteController(SprintDb db) : ControllerBase
{
    private Guid CurrentUserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    private async Task<string?> Validate(ReportInput x)
    {
        if(x.Type is not ("LOST" or "FOUND")) return "Chọn loại bài LOST hoặc FOUND.";
        if(string.IsNullOrWhiteSpace(x.ItemName)||x.ItemName.Trim().Length<3||x.ItemName.Length>140)
            return "Tên vật phẩm cần từ 3 đến 140 ký tự.";
        if(string.IsNullOrWhiteSpace(x.Description)||x.Description.Trim().Length<10||x.Description.Length>1500)
            return "Mô tả cần từ 10 đến 1500 ký tự.";
        if(!await db.Categories.AnyAsync(c=>c.Id==x.CategoryId)) return "Vui lòng chọn danh mục hợp lệ.";
        if(!await db.Locations.AnyAsync(l=>l.Id==x.LocationId)) return "Vui lòng chọn khu vực hợp lệ.";
        if(x.EventTime==default) return "Vui lòng nhập thời gian mất/nhặt đồ.";
        var at=x.EventTime.Kind==DateTimeKind.Utc?x.EventTime:x.EventTime.ToUniversalTime();
        if(at>DateTime.UtcNow.AddHours(2)||at<DateTime.UtcNow.AddYears(-5)) return "Thời gian không hợp lệ.";
        return null;
    }
    private static void Copy(ItemReport target,ReportInput x)
    {
        target.Type=x.Type;target.ItemName=x.ItemName.Trim();target.Description=x.Description.Trim();
        target.CategoryId=x.CategoryId;target.LocationId=x.LocationId;
        target.EventTime=x.EventTime.Kind==DateTimeKind.Utc?x.EventTime:x.EventTime.ToUniversalTime();
        target.UpdatedAt=DateTime.UtcNow;
    }
    // US-01 create + input validation + PostgreSQL persist
    [HttpPost]
    public async Task<IActionResult> Create(ReportInput input)
    {
        var error=await Validate(input);
        if(error!=null)return BadRequest(new {message=error});
        var report=new ItemReport {UserId=CurrentUserId};
        Copy(report,input);
        db.Reports.Add(report);
        await db.SaveChangesAsync();
        return Created($"/api/reports/{report.Id}",new {id=report.Id,message="Đăng tin thành công."});
    }
    // Sprint 1 CRUD: only the owner may edit/remove their report.
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id,ReportInput input)
    {
        var report=await db.Reports.FindAsync(id);
        if(report==null||report.Status!="OPEN")return NotFound();
        if(report.UserId!=CurrentUserId)return Forbid();
        if(report.Type!=input.Type)return BadRequest(new {message="Không thể thay đổi loại bài."});
        var error=await Validate(input);
        if(error!=null)return BadRequest(new {message=error});
        Copy(report,input);
        await db.SaveChangesAsync();
        return Ok(new {message="Đã cập nhật bài."});
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var report=await db.Reports.FindAsync(id);
        if(report==null)return NotFound();
        if(report.UserId!=CurrentUserId)return Forbid();
        db.Reports.Remove(report);
        await db.SaveChangesAsync();
        return Ok(new {message="Đã xóa bài."});
    }
}
