using System;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.EventSender;

namespace Vostok.ServiceDiscovery.Telemetry.EventContext
{
    [PublicAPI]
    public class ServiceDiscoveryEventContextConfig
    {
        public ServiceDiscoveryEventContextConfig([NotNull] IServiceDiscoveryEventSender sender)
            => Sender = sender ?? throw new ArgumentNullException(nameof(sender));
        
        [NotNull]
        public IServiceDiscoveryEventSender Sender { get; }
    }
}