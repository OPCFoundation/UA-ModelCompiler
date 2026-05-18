using Opc.Ua;

namespace SchemaGeneration.Tests
{
    [TestClass]
    public class GlobalSettings
    {
        private static ITelemetryContext m_telemetry;
        private static bool m_initialized = false;

        public static ITelemetryContext Telemetry => m_telemetry;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            if (m_initialized)
            {
                return;
            }

            m_initialized = true;
            m_telemetry = DefaultTelemetry.Create(_ => { });
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if (m_initialized)
            {
                m_initialized = false;
            }
        }
    }
}