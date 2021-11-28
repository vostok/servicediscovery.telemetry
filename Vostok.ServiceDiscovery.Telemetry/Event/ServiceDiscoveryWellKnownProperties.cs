using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry.Event
{
    [PublicAPI]
    public static class ServiceDiscoveryWellKnownProperties
    {
        public const string CreatorId = "userId";
        public const string Description = "description";
        
        public const string Dependencies = "dependencies";
    }
}