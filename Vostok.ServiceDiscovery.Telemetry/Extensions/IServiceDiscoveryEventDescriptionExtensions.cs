using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.EventDescription;

namespace Vostok.ServiceDiscovery.Telemetry.Extensions
{
    [PublicAPI]
    public static class IServiceDiscoveryEventDescriptionExtensions
    {
        [NotNull]
        public static IServiceDiscoveryEventDescription SetDescription(this IServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string description) =>
            serviceDiscoveryEventDescription.AddProperty(ServiceDiscoveryEventKeys.Description, description);

        [NotNull]
        public static IServiceDiscoveryEventDescription SetUserId(this IServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string userId) =>
            serviceDiscoveryEventDescription.AddProperty(ServiceDiscoveryEventKeys.CreatorId, userId);

        [NotNull]
        public static IServiceDiscoveryEventDescription SetDependencies(this IServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string dependencies) =>
            serviceDiscoveryEventDescription.AddProperty(ServiceDiscoveryEventKeys.Dependencies, dependencies);
    }
}