using Foundly.Sprint1.Domain;
namespace Foundly.Sprint1.Services;
public static class ReportView
{
    public static object Public(ItemReport r) => new
    {
        r.Id,r.Type,r.ItemName,r.Description,r.CategoryId,r.LocationId,
        category=r.Category?.Name,location=r.Location?.Name,r.Status,
        r.EventTime,r.CreatedAt,r.UpdatedAt,r.UserId,
        reporter=r.User?.FullName
    };
}
