using Foundly.Sprint1.Domain;
using Microsoft.EntityFrameworkCore;
namespace Foundly.Sprint1.Services;
// US-03: searching is performed by PostgreSQL; no entire-table download.
public static class KeywordSearch
{
    public static IQueryable<ItemReport> ApplyKeyword(this IQueryable<ItemReport> query,string? raw)
    {
        if (string.IsNullOrWhiteSpace(raw)) return query;
        var keyword=raw.Trim();
        if (keyword.Length>100) keyword=keyword[..100];
        // Escape LIKE wildcard characters so user input is treated as a literal substring.
        var escaped=keyword.Replace("\\", "\\\\").Replace("%", "\\%").Replace("_", "\\_");
        var term="%"+escaped+"%";
        return query.Where(r=>EF.Functions.ILike(r.ItemName,term,"\\") || EF.Functions.ILike(r.Description,term,"\\"));
    }
}
