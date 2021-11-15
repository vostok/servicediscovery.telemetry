using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.EventDescription;

namespace Vostok.ServiceDiscovery.Telemetry.Extensions
{
    [PublicAPI]
    public static class ServiceDiscoveryEventDescriptionExtensions
    {
        [NotNull]
        public static ServiceDiscoveryEventDescription SetDescription(this ServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string description) =>
            serviceDiscoveryEventDescription.AddProperties(ServiceDiscoveryEventKeys.Description, description);

        [NotNull]
        public static ServiceDiscoveryEventDescription SetUserId(this ServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string userId) =>
            serviceDiscoveryEventDescription.AddProperties(ServiceDiscoveryEventKeys.CreatorId, userId);

        [NotNull]
        public static ServiceDiscoveryEventDescription SetDependencies(this ServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string dependencies) =>
            serviceDiscoveryEventDescription.AddProperties(ServiceDiscoveryEventKeys.Dependencies, dependencies);
    }
}