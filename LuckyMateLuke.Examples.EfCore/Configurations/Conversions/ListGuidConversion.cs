using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyMateLuke.Examples.EfCore.Configurations.Conversions;

public static class ListGuidConversion 
{
    public static PropertyBuilder<List<Guid>> ApplyStringConversion(this PropertyBuilder<List<Guid>> pb)
    {
        return pb.HasConversion(d => d.From(), d => d.ToGuidList());
    }

    private static List<Guid> ToGuidList(this string csvList)
    {
        var guids = new List<Guid>();
        var values = csvList.Split(",").ToList();
        foreach (var guid in values)
            if (Guid.TryParse(guid, out var converted))
                guids.Add(converted);
        return guids;
    }
    
    private static string From(this IEnumerable<Guid> guids)
    {
        var guidString = guids.Aggregate(string.Empty, (current, guid) => current + (guid + ","));
        return guidString.Remove(guidString.Length - 1);
    }
}