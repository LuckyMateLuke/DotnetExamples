using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace LuckyMateLuke.Examples.EfCore.QueryTest;

public class XUnitLoggerProvider : ILoggerProvider
{
    private readonly ITestOutputHelper _log;
            
    public XUnitLoggerProvider(ITestOutputHelper log)
    {
        _log = log;
    }

    public ILogger CreateLogger(string categoryName) => new XUnitLogger(_log);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        // Cleanup
    }
}
