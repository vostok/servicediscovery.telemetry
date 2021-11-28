using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;
using Vostok.ServiceDiscovery.Telemetry.EventDescription;

namespace Vostok.ServiceDiscovery.Telemetry.Extensions
{
    [PublicAPI]
    public static class IServiceDiscoveryEventDescriptionExtensions
    {
        [NotNull]
        public static IServiceDiscoveryEventDescription SetDescription(this IServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string description) =>
            serviceDiscoveryEventDescription.AddProperty(ServiceDiscoveryWellKnownProperties.Description, description);

        [NotNull]
        public static IServiceDiscoveryEventDescription SetUserId(this IServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string userId) =>
            serviceDiscoveryEventDescription.AddProperty(ServiceDiscoveryWellKnownProperties.CreatorId, userId);

        [NotNull]
        public static IServiceDiscoveryEventDescription SetDependencies(this IServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string dependencies) =>
            serviceDiscoveryEventDescription.AddProperty(ServiceDiscoveryWellKnownProperties.Dependencies, dependencies);
    }
}