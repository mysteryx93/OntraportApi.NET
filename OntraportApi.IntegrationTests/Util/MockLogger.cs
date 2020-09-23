using System;
using System.Text;
using HanumanInstitute.Validators;
using Microsoft.Extensions.Logging;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    /// <summary>
    /// Registers all logs into a StringBuilder that can be recovered with ToString.
    /// </summary>
    public class MockLogger<T> : ILogger<T>
    {
        private readonly StringBuilder _log = new StringBuilder();

        public bool RecordRequests { get; set; } = true;
        public bool RecordResponses { get; set; } = true;

        public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();

        public bool IsEnabled(LogLevel logLevel) => logLevel == LogLevel.Trace ? RecordResponses : RecordRequests;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (logLevel == LogLevel.Information && RecordRequests)
            {
                _log.AppendLine(state.ToStringInvariant());
            }
            else if (logLevel == LogLevel.Trace && RecordResponses)
            {
                _log.AppendLine(state.ToStringInvariant());
                _log.AppendLine();
            }
        }

        public override string ToString() => _log.ToString();
    }
}
