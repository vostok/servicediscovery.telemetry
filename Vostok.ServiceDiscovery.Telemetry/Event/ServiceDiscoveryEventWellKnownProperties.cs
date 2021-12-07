using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry.Event
{
    [PublicAPI]
    public static class ServiceDiscoveryEventWellKnownProperties
    {
        public const string UserId = "userId";
        public const string Description = "description";

        public const string Dependencies = "dependencies";
    }
}