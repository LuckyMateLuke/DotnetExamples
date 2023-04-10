using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace LuckyMateLuke.Examples.EfCore.QueryTest;

/// <summary>
/// Lightweight option to reveal the generated sql code in de output window
/// </summary>
public class QueryTest
{
    public QueryTest(ITestOutputHelper testOutputHelper)
    {
        TestOutputHelper = testOutputHelper;
    }

    private ITestOutputHelper TestOutputHelper { get; }

    [Fact]
    public void CheckQuery()
    {
        var optionsBuilder = CreateBuilder();
        using var databaseContext = new CustomDbContext(optionsBuilder.Options);

        var query = databaseContext
            .JoinParentStudent
            .TagWithCallSite();

        var str = query.ToQueryString();

        Console.WriteLine(str);

        Assert.True(true);
    }

    private DbContextOptionsBuilder<CustomDbContext> CreateBuilder()
    {
        var connectionString = "Server=(local);Database=ExampleDb;Trusted_Connection=True;";
        DbContextOptionsBuilder<CustomDbContext> optionsBuilder;
        optionsBuilder = new DbContextOptionsBuilder<CustomDbContext>();
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(b =>
        {
            b.AddProvider(new XUnitLoggerProvider(TestOutputHelper));
        }));
        optionsBuilder.UseSqlServer(connectionString);
        return optionsBuilder;
    }
}