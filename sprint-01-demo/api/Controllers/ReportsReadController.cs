using Foundly.Sprint1.Data;
using Foundly.Sprint1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Foundly.Sprint1.Controllers;
[ApiController,Route("api/reports")]
public class ReportsReadController(SprintDb db) : ControllerBase
{
    // US-02 (list), US-03 (keyword search), US-04 (category/date/location filters).
    [HttpGet]
    public async Task<IActionResult> List([FromQuery]string? q,[FromQuery]string? type,
        [FromQuery]int? categoryId,[FromQuery]int? locationId,[FromQuery]DateOnly? dateFrom,
        [FromQuery]DateOnly? dateTo,[FromQuery]int page=1)
    {
        if(dateFrom.HasValue && dateTo.HasValue && dateFrom.Value>dateTo.Value)
            return BadRequest(new {message="Ngày bắt đầu không được sau ngày kết thúc."});
        page=Math.Clamp(page,1,10000);
        const int pageSize=12;
        var query=db.Reports.AsNoTracking().Where(r=>r.Status=="OPEN")
            .ApplyKeyword(q).ApplyFilters(type,categoryId,locationId,dateFrom,dateTo);
        var total=await query.CountAsync();
        var items=await query.Include(r=>r.User).Include(r=>r.Category).Include(r=>r.Location)
            .OrderByDescending(r=>r.CreatedAt).Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        return Ok(new {total,page,pageSize,items=items.Select(ReportView.Public)});
    }
    // US-05: show complete public details of one report.
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Detail(Guid id)
    {
        var r=await db.Reports.AsNoTracking().Include(x=>x.Category).Include(x=>x.Location).Include(x=>x.User)
            .FirstOrDefaultAsync(x=>x.Id==id && x.Status=="OPEN");
        return r==null?NotFound(new {message="Bài đăng không tồn tại."}):Ok(ReportView.Public(r));
    }
}
