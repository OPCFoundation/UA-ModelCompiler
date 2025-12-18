using Microsoft.Extensions.Logging;
using Opc.Ua;
using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Threading.Tasks;

namespace ModelCompiler
{
    public sealed class ConsoleTelemetry : ITelemetryContext, IDisposable
    {
        public ConsoleTelemetry(Action<ILoggingBuilder> configure = null)
        {
            LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory
                .Create(builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Information);
                    configure?.Invoke(builder);
                })
                .AddSerilog(Log.Logger);

            ActivitySource = new ActivitySource("Quickstarts", "1.0.0");

            m_logger = LoggerFactory.CreateLogger("Main");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += Unobserved_TaskException;
        }

        /// <inheritdoc/>
        public ILoggerFactory LoggerFactory { get; internal set; }

        /// <inheritdoc/>
        public Meter CreateMeter()
        {
            return new Meter("Quickstarts", "1.0.0");
        }

        /// <inheritdoc/>
        public ActivitySource ActivitySource { get; }

        /// <inheritdoc/>
        public void Dispose()
        {
            CreateMeter().Dispose();
            ActivitySource.Dispose();
            LoggerFactory.Dispose();

            AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException -= Unobserved_TaskException;
        }

        public void ConfigureLogging()
        {
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration().Enrich
                .FromLogContext();

            loggerConfiguration.WriteTo.Console(
                restrictedToMinimumLevel: LogEventLevel.Information,
                formatProvider: CultureInfo.InvariantCulture);

#if DEBUG
            loggerConfiguration.WriteTo.Debug(
                    restrictedToMinimumLevel: LogEventLevel.Information,
                    formatProvider: CultureInfo.InvariantCulture);
#endif

            // create the serilog logger
            Serilog.Core.Logger serilogger = loggerConfiguration.CreateLogger();

            // create the ILogger for Opc.Ua.Core
            LoggerFactory = LoggerFactory.AddSerilog(serilogger);
            m_logger = LoggerFactory.CreateLogger("Main");
        }

        private void CurrentDomain_UnhandledException(
            object sender,
            UnhandledExceptionEventArgs args)
        {
            m_logger.LogCritical(
                args.ExceptionObject as Exception,
                "Unhandled Exception: (IsTerminating: {IsTerminating})",
                args.IsTerminating);
        }

        private void Unobserved_TaskException(
            object sender,
            UnobservedTaskExceptionEventArgs args)
        {
            m_logger.LogCritical(
                args.Exception,
                "Unobserved Task Exception (Observed: {Observed})",
                args.Observed);
        }

        private Microsoft.Extensions.Logging.ILogger m_logger;
    }
}
