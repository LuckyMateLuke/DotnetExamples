using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LuckyMateLuke.Examples.EfCore.Configurations.Conversions;

// Dit lijkt niet te werken
public class ListIntConversion : ValueConverter<List<int>, string>
{
    public ListIntConversion()
        : base(
            v => string.Empty,
            v => new List<int>())
    {
    }
}

public static class Xyz
{
    public static PropertyBuilder<List<int>> ApplyStringConversion(this PropertyBuilder<List<int>> pb)
    {
        return pb.HasConversion(d => d.From(), d => d.ToGuidList());
    }

    private static List<int> ToGuidList(this string csvList)
    {
        var guids = new List<int>();
        var values = csvList.Split(",").ToList();
        foreach (var guid in values)
            if (int.TryParse(guid, out var converted))
                guids.Add(converted);
        return guids;
    }
    
    private static string From(this IEnumerable<int> guids)
    {
        var guidString = guids.Aggregate(string.Empty, (current, guid) => current + (guid + ","));
        return guidString.Remove(guidString.Length - 1);
    }
}