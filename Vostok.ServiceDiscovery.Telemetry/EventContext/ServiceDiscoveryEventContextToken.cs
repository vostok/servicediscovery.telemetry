using System;
using JetBrains.Annotations;
using Vostok.Context;
using Vostok.ServiceDiscovery.Telemetry.EventsBuilder;

namespace Vostok.ServiceDiscovery.Telemetry.EventContext
{
    [PublicAPI]
    public class ServiceDiscoveryEventContextToken : IDisposable
    {
        private readonly IDisposable scope;

        public ServiceDiscoveryEventContextToken([NotNull] Action<IServiceDiscoveryEventsBuilder> setup)
        {
            var newBuilder = FlowingContext.Globals.Get<ServiceDiscoveryEventsBuilder>()?.Clone() ?? new ServiceDiscoveryEventsBuilder();
            setup.Invoke(newBuilder);

            scope = FlowingContext.Globals.Use(newBuilder);
        }

        public void Dispose()
        {
            scope?.Dispose();
        }
    }
}