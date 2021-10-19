using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventBuilder
{
    [PublicAPI]
    public interface IServiceDiscoveryEventsBuilder
    {
        [NotNull]
        IEnumerable<ServiceDiscoveryEvent> Build();
        
        [NotNull]
        IServiceDiscoveryEventsBuilder SetApplication([NotNull] string application);
        
        [NotNull]
        IServiceDiscoveryEventsBuilder SetEnvironment([NotNull] string environment);
        
        [NotNull]
        IServiceDiscoveryEventsBuilder SetEventKind(ServiceDiscoveryEventKind eventKind);

        [NotNull]
        IServiceDiscoveryEventsBuilder SetProperties(params (string key, string value)[] properties);
        
        [NotNull]
        IServiceDiscoveryEventsBuilder SetReplicas(params Uri[] replicas);
    }
}