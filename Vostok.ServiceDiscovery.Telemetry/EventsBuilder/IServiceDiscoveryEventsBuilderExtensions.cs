using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventsBuilder
{
    [PublicAPI]
    public static class IServiceDiscoveryEventsBuilderExtensions
    {
        [NotNull]
        public static IServiceDiscoveryEventsBuilder SetDescription(this IServiceDiscoveryEventsBuilder serviceDiscoveryEventsBuilder, [NotNull] string description) =>
            serviceDiscoveryEventsBuilder.SetProperty(ServiceDiscoveryEventWellKnownProperties.Description, description);

        [NotNull]
        public static IServiceDiscoveryEventsBuilder SetUserId(this IServiceDiscoveryEventsBuilder serviceDiscoveryEventsBuilder, [NotNull] string userId) =>
            serviceDiscoveryEventsBuilder.SetProperty(ServiceDiscoveryEventWellKnownProperties.UserId, userId);

        [NotNull]
        public static IServiceDiscoveryEventsBuilder SetDependencies(this IServiceDiscoveryEventsBuilder serviceDiscoveryEventsBuilder, [NotNull] string dependencies) =>
            serviceDiscoveryEventsBuilder.SetProperty(ServiceDiscoveryEventWellKnownProperties.Dependencies, dependencies);
    }
}