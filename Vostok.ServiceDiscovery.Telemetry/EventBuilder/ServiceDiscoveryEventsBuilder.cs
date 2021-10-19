using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventBuilder
{
    [PublicAPI]
    public class ServiceDiscoveryEventsBuilder: IServiceDiscoveryEventsBuilder
    {
        public IEnumerable<ServiceDiscoveryEvent> Build() =>
            throw new NotImplementedException();

        public IServiceDiscoveryEventsBuilder SetApplication(string application) =>
            throw new NotImplementedException();

        public IServiceDiscoveryEventsBuilder SetEnvironment(string environment) =>
            throw new NotImplementedException();

        public IServiceDiscoveryEventsBuilder SetEventKind(ServiceDiscoveryEventKind eventKind) =>
            throw new NotImplementedException();

        public IServiceDiscoveryEventsBuilder SetProperties(params (string key, string value)[] properties) =>
            throw new NotImplementedException();

        public IServiceDiscoveryEventsBuilder SetReplicas(params Uri[] replicas) =>
            throw new NotImplementedException();
    }
}