using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry.EventDescription
{
    [PublicAPI]
    public static class ServiceDiscoveryEventDescriptionExtensions
    {
        [NotNull]
        public static ServiceDiscoveryEventDescription SetDescription(this ServiceDiscoveryEventDescription serviceDiscoveryEventsBuilder, [NotNull] string description) =>
            serviceDiscoveryEventsBuilder.AddProperties((ServiceDiscoveryEventKeys.EventDescription, description));
        
        [NotNull]
        public static ServiceDiscoveryEventDescription SetUserId(this ServiceDiscoveryEventDescription serviceDiscoveryEventsBuilder, [NotNull] string userId) =>
            serviceDiscoveryEventsBuilder.AddProperties((ServiceDiscoveryEventKeys.EventCreatorId, userId));
    }
}