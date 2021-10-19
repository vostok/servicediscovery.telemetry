using System.Threading;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.EventBuilder;

namespace Vostok.ServiceDiscovery.Telemetry
{
    [PublicAPI]
    public static class ServiceDiscoveryContext
    {
        private static readonly AsyncLocal<IServiceDiscoveryEventsBuilder> Container = new AsyncLocal<IServiceDiscoveryEventsBuilder>();

        [CanBeNull]
        public static IServiceDiscoveryEventsBuilder CurrentBuilder
        {
            get => Container.Value;
            set => Container.Value = value;
        }
    }
}