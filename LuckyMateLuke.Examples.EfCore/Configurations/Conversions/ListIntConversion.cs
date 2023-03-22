using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LuckyMateLuke.Examples.EfCore.Conversions;

public class ListIntConversion : ValueConverter<List<int>, string>
{
    public ListIntConversion()
        : base(
            v => string.Empty,
            v => new List<int>())
    {
    }
}