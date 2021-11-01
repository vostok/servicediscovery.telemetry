using System.Threading;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.EventDescription;

namespace Vostok.ServiceDiscovery.Telemetry
{
    [PublicAPI]
    public static class ServiceDiscoveryEventDescriptionContext
    {
        private static readonly AsyncLocal<ServiceDiscoveryEventDescription> DescriptionContainer = new AsyncLocal<ServiceDiscoveryEventDescription>();

        [CanBeNull]
        public static ServiceDiscoveryEventDescription CurrentDescription
        {
            get => DescriptionContainer.Value;
            private set => DescriptionContainer.Value = value;
        }

        [NotNull]
        public static ServiceDiscoveryEventDescription Create()
        {
            CurrentDescription = new ServiceDiscoveryEventDescription();
            return CurrentDescription;
        }

        [NotNull]
        public static ServiceDiscoveryEventDescription GetOrCreate()
        {
            var current = CurrentDescription ?? new ServiceDiscoveryEventDescription();
            CurrentDescription = current;
            return CurrentDescription;
        }
    }
}