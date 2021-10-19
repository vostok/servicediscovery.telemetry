using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry.Event
{
    [PublicAPI]
    public enum ServiceDiscoveryEventKind
    {
        AddToBlackList = 0,
        RemoveFromBlackList = 1,
        ReplicaStart = 2,
        ReplicaStop = 3
    }
}