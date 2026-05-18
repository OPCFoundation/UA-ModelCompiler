using Opc.Ua;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Logging;

namespace SchemaGeneration.Tests
{
    public sealed class DefaultTelemetry : ITelemetryContext, IDisposable
    {
        private Microsoft.Extensions.Logging.ILogger m_logger;

        public DefaultTelemetry()
        {
            LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory
                .Create(builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Information);
                    builder.AddConsole();
                });

            ActivitySource = new ActivitySource("Default", "1.0.0");
            m_logger = LoggerFactory.CreateLogger("Main");
        }

        /// <inheritdoc/>
        public ILoggerFactory LoggerFactory { get; internal set; }

        /// <inheritdoc/>
        public Meter CreateMeter()
        {
            return new Meter("Default", "1.0.0");
        }

        /// <inheritdoc/>
        public ActivitySource ActivitySource { get; }

        /// <inheritdoc/>
        public void Dispose()
        {
            CreateMeter().Dispose();
            ActivitySource.Dispose();
            LoggerFactory.Dispose();
        }
    }
}
