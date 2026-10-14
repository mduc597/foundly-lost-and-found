using Foundly.Sprint1.Domain;
namespace Foundly.Sprint1.Services;
// US-04: filters apply to the SQL query; posting dates use Vietnam timezone (UTC+7).
public static class ReportFilters
{
    public static IQueryable<ItemReport> ApplyFilters(this IQueryable<ItemReport> query,
        string? type,int? categoryId,int? locationId,DateOnly? dateFrom,DateOnly? dateTo)
    {
        if (type=="LOST" || type=="FOUND") query=query.Where(r=>r.Type==type);
        if (categoryId.HasValue) query=query.Where(r=>r.CategoryId==categoryId.Value);
        if (locationId.HasValue) query=query.Where(r=>r.LocationId==locationId.Value);
        if (dateFrom.HasValue)
        {
            var start=DateTime.SpecifyKind(dateFrom.Value.ToDateTime(TimeOnly.MinValue).AddHours(-7),DateTimeKind.Utc);
            query=query.Where(r=>r.CreatedAt>=start);
        }
        if (dateTo.HasValue)
        {
            var endExclusive=DateTime.SpecifyKind(dateTo.Value.AddDays(1).ToDateTime(TimeOnly.MinValue).AddHours(-7),DateTimeKind.Utc);
            query=query.Where(r=>r.CreatedAt<endExclusive);
        }
        return query;
    }
}
