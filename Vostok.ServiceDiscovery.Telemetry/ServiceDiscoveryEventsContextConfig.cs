using System;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.EventsSender;

namespace Vostok.ServiceDiscovery.Telemetry
{
    /// <summary>
    /// Configuration governing behaviour of <see cref="ServiceDiscoveryEventsContext"/>.
    /// </summary>
    [PublicAPI]
    public class ServiceDiscoveryEventsContextConfig
    {
        public ServiceDiscoveryEventsContextConfig([NotNull] IServiceDiscoveryEventsSender sender)
            => Sender = sender ?? throw new ArgumentNullException(nameof(sender));

        /// <summary>
        /// <para>Gets the sender used to sending constructed events. See <see cref="IServiceDiscoveryEventsSender"/> for more details.</para>
        /// <para>This configuration parameter is <b>required</b>: <c>null</c> values are not allowed.</para>
        /// </summary>
        [NotNull]
        public IServiceDiscoveryEventsSender Sender { get; }
    }
}