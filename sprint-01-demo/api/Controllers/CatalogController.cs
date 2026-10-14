using Foundly.Sprint1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Foundly.Sprint1.Controllers;
[ApiController,Route("api/catalog")]
public class CatalogController(SprintDb db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get() => Ok(new
    {
        categories=await db.Categories.AsNoTracking().OrderBy(x=>x.Id).ToListAsync(),
        locations=await db.Locations.AsNoTracking().OrderBy(x=>x.Id).ToListAsync()
    });
}
