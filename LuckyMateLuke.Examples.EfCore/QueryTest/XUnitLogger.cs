using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace LuckyMateLuke.Examples.EfCore.QueryTest
{
    public class XUnitLogger : ILogger, IDisposable
    {
        private readonly ITestOutputHelper _log;

        public XUnitLogger(ITestOutputHelper log)
        {
            _log = log;
        }

        public IDisposable BeginScope<TState>(TState state) => this;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception, string> formatter)
        {
            _log.WriteLine(state.ToString());
        }

        protected virtual void Dispose(bool disposing)
        {
            // Cleanup
        }
    }
}
