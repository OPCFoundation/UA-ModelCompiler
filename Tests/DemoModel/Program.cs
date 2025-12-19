using System;
using System.IO;
using Opc.Ua;
using ModelCompiler;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;

namespace DemoModel
{
    static class Program
    {
        private static ITelemetryContext m_telemetry = DefaultTelemetry.Create(_ => {});

        public static async Task<int> Main(string[] args)
        {
            TextWriter output = Console.Out;

            await output.WriteLineAsync(
                $"{(Utils.IsRunningOnMono() ? "Mono" : ".NET Core")} OPC UA Reference Server").ConfigureAwait(false);

            await output.WriteLineAsync(
                $"OPC UA library: {Utils.GetAssemblyBuildNumber()}" +
                $"@ {Utils.GetAssemblyTimestamp().ToString("G", CultureInfo.InvariantCulture)}" +
                $"-- {Utils.GetAssemblySoftwareVersion()}").ConfigureAwait(false);
         
            // The application name and config file names
            var applicationName = Utils.IsRunningOnMono() ? "MonoReferenceServer" : "ConsoleReferenceServer";
            var configSectionName = Utils.IsRunningOnMono() ? "Quickstarts.MonoReferenceServer" : "Quickstarts.ReferenceServer";

            try
            {
                // create the UA server
                var server = new UAServer<ReferenceServer>(output)
                {
                    AutoAccept = true,
                    Password = null
                };

                // load the server configuration, validate certificates
                await output.WriteLineAsync($"Loading configuration from {configSectionName}.").ConfigureAwait(false);
                await server.LoadAsync(m_telemetry, applicationName, configSectionName).ConfigureAwait(false);

                // check or renew the certificate
                await output.WriteLineAsync("Check the certificate.").ConfigureAwait(false);
                await server.CheckCertificateAsync(false).ConfigureAwait(false);

                // start the server
                await output.WriteLineAsync("Start the server.").ConfigureAwait(false);
                await server.StartAsync().ConfigureAwait(false);

                await output.WriteLineAsync("Server started. Press Ctrl-C to exit...").ConfigureAwait(false);

                // wait for timeout or Ctrl-C
                using var quitEvent = CtrlCHandler();
                bool ctrlc = quitEvent.WaitOne(300000);

                // stop server. May have to wait for clients to disconnect.
                await output.WriteLineAsync("Server stopped. Waiting for exit...").ConfigureAwait(false);
                await server.StopAsync().ConfigureAwait(false);

                return 0;
            }
            catch (Exception exception)
            {
                await output.WriteLineAsync($"The application exits with error: {exception}").ConfigureAwait(false);
                return (int)-1;
            }
        }

        /// <summary>
        /// Create an event which is set if a user
        /// enters the Ctrl-C key combination.
        /// </summary>
        public static ManualResetEvent CtrlCHandler()
        {
            var quitEvent = new ManualResetEvent(false);
            try
            {
                Console.CancelKeyPress += (_, eArgs) => {
                    quitEvent.Set();
                    eArgs.Cancel = true;
                };
            }
            finally
            {
                // intentionally left blank
            }
            return quitEvent;
        }
    }
}
