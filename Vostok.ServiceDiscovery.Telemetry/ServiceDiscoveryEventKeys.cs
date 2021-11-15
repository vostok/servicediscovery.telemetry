using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry
{
    [PublicAPI]
    public static class ServiceDiscoveryEventKeys
    {
        public const string CreatorId = "userId";
        public const string Description = "description";
        
        public const string Dependencies = "dependencies";
    }
}