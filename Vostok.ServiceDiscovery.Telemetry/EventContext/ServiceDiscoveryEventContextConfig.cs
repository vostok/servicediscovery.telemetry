using System;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.EventSender;

namespace Vostok.ServiceDiscovery.Telemetry.EventContext
{
    /// <summary>
    /// Configuration governing behaviour of <see cref="ServiceDiscoveryEventContext"/>.
    /// </summary>
    [PublicAPI]
    public class ServiceDiscoveryEventContextConfig
    {
        public ServiceDiscoveryEventContextConfig([NotNull] IServiceDiscoveryEventSender sender)
            => Sender = sender ?? throw new ArgumentNullException(nameof(sender));

        /// <summary>
        /// <para>Gets the sender used to sending constructed events. See <see cref="IServiceDiscoveryEventSender"/> for more details.</para>
        /// <para>This configuration parameter is <b>required</b>: <c>null</c> values are not allowed.</para>
        /// </summary>
        [NotNull]
        public IServiceDiscoveryEventSender Sender { get; }
    }
}