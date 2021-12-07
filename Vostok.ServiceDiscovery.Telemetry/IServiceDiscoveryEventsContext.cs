using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;
using Vostok.ServiceDiscovery.Telemetry.EventsBuilder;

namespace Vostok.ServiceDiscovery.Telemetry
{
    /// <summary>
    /// <see cref="IServiceDiscoveryEventsContext"/> is the main point of sending servicediscovery telemetry.
    /// See <see cref="CurrentEvents"/>, <see cref="Send"/>, <see cref="SendFromContext"/> for details. 
    /// </summary>
    [PublicAPI]
    public interface IServiceDiscoveryEventsContext
    {
        /// <summary>
        /// <para>Returns current state of the constructed events.</para>
        /// <para>Based on the current <see cref="IServiceDiscoveryEventsBuilder"/> configuration produced in the <see cref="ServiceDiscoveryEventsContextToken"/>.</para>
        /// <para>Empty if environment, application and replicas is not set.</para>
        /// </summary>
        [NotNull]
        IEnumerable<ServiceDiscoveryEvent> CurrentEvents { get; }
        
        /// <summary>
        /// Sends ready-made events using <see cref="ServiceDiscoveryEventsContextConfig.Sender"/>.
        /// </summary>
        void Send(ServiceDiscoveryEvent @event);
        
        /// <summary>
        /// Sends events from <see cref="CurrentEvents"/> using <see cref="ServiceDiscoveryEventsContextConfig.Sender"/>.
        /// </summary>
        void SendFromContext();
    }
}