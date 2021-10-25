using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry.Event
{
    [PublicAPI]
    public enum ServiceDiscoveryEventKind
    {
        ReplicaStart = 0,
        ReplicaStop = 1,
        AddToBlackList = 2,
        RemoveFromBlackList = 3
    }
}