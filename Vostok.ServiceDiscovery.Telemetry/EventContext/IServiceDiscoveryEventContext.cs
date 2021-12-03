using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;
using Vostok.ServiceDiscovery.Telemetry.EventsBuilder;

namespace Vostok.ServiceDiscovery.Telemetry.EventContext
{
    /// <summary>
    /// <see cref="IServiceDiscoveryEventContext"/> is the main point of sending servicediscovery telemetry.
    /// See <see cref="CurrentEvents"/>, <see cref="Send"/>, <see cref="TrySendFromContext"/> for details. 
    /// </summary>
    [PublicAPI]
    public interface IServiceDiscoveryEventContext
    {
        /// <summary>
        /// <para>Returns current state of the constructed events.</para>
        /// <para>Based on the current <see cref="IServiceDiscoveryEventsBuilder"/> configuration produced in the <see cref="ServiceDiscoveryEventContextToken"/>.</para>
        /// <para>Empty if environment, application and replicas is not set.</para>
        /// </summary>
        [NotNull]
        IReadOnlyList<ServiceDiscoveryEvent> CurrentEvents { get; }
        
        /// <summary>
        /// Sends ready-made events using <see cref="ServiceDiscoveryEventContextConfig.Sender"/>.
        /// </summary>
        void Send(ServiceDiscoveryEvent @event);
        
        /// <summary>
        /// Sends events from <see cref="CurrentEvents"/> using <see cref="ServiceDiscoveryEventContextConfig.Sender"/>.
        /// </summary>
        bool TrySendFromContext();
    }
}