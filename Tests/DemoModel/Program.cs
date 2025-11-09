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
        private static ConsoleTelemetry m_telemetry = new();

        public static async Task<int> Main(string[] args)
        {
            m_telemetry.ConfigureLogging();

            TextWriter output = Console.Out;
            output.WriteLine("{0} OPC UA Reference Server", Utils.IsRunningOnMono() ? "Mono" : ".NET Core");

            output.WriteLine("OPC UA library: {0} @ {1} -- {2}",
                Utils.GetAssemblyBuildNumber(),
                Utils.GetAssemblyTimestamp().ToString("G", CultureInfo.InvariantCulture),
                Utils.GetAssemblySoftwareVersion());

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
                output.WriteLine("Loading configuration from {0}.", configSectionName);
                await server.LoadAsync(m_telemetry, applicationName, configSectionName).ConfigureAwait(false);

                // check or renew the certificate
                output.WriteLine("Check the certificate.");
                await server.CheckCertificateAsync(false).ConfigureAwait(false);

                // start the server
                output.WriteLine("Start the server.");
                await server.StartAsync().ConfigureAwait(false);

                output.WriteLine("Server started. Press Ctrl-C to exit...");

                // wait for timeout or Ctrl-C
                var quitEvent = CtrlCHandler();
                bool ctrlc = quitEvent.WaitOne(300000);

                // stop server. May have to wait for clients to disconnect.
                output.WriteLine("Server stopped. Waiting for exit...");
                await server.StopAsync().ConfigureAwait(false);

                return 0;
            }
            catch (Exception eee)
            {
                output.WriteLine("The application exits with error: {0}", eee.Message);
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
            catch
            {
                // intentionally left blank
            }
            return quitEvent;
        }
    }
}
