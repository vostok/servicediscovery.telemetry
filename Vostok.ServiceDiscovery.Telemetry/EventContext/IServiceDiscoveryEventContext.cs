using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventContext
{
    [PublicAPI]
    public interface IServiceDiscoveryEventContext
    {
        [NotNull]
        IReadOnlyList<ServiceDiscoveryEvent> CurrentEvents { get; }
        
        void Send(ServiceDiscoveryEvent @event);
        bool TrySendFromContext();
    }
}