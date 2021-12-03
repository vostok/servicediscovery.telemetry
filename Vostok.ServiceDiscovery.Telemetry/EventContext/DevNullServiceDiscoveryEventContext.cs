﻿using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventContext
{
    /// <summary>
    /// A trivial implementation of <see cref="IServiceDiscoveryEventContext"/> that simply does nothing.
    /// </summary>
    [PublicAPI]
    public class DevNullServiceDiscoveryEventContext : IServiceDiscoveryEventContext
    {
        public IReadOnlyList<ServiceDiscoveryEvent> CurrentEvents { get; } = new List<ServiceDiscoveryEvent>();

        public void Send(ServiceDiscoveryEvent @event)
        {
        }

        public bool TrySendFromContext() => true;
    }
}