using JetBrains.Annotations;
using Vostok.Context;
using Vostok.ServiceDiscovery.Telemetry.EventDescription;

namespace Vostok.ServiceDiscovery.Telemetry
{
    [PublicAPI]
    public static class ServiceDiscoveryEventDescriptionContext
    {
        [CanBeNull]
        public static IServiceDiscoveryEventDescription CurrentDescription
        {
            get => FlowingContext.Globals.Get<IServiceDiscoveryEventDescription>();
            set => FlowingContext.Globals.Set(value);
        }

        [NotNull]
        public static IServiceDiscoveryEventDescription Create()
        {
            return SetScopedDescription(new ServiceDiscoveryEventDescription());
        }

        [NotNull]
        public static IServiceDiscoveryEventDescription Continue()
        {
            return SetScopedDescription(CurrentDescription != null
                ? new ServiceDiscoveryEventDescription(CurrentDescription)
                : new ServiceDiscoveryEventDescription());
        }

        private static IServiceDiscoveryEventDescription SetScopedDescription(ServiceDiscoveryEventDescription eventDescription)
        {
            var scope = FlowingContext.Globals.Use(eventDescription);
            eventDescription.SetDescriptionScope(scope);
            return eventDescription;
        }
    }
}