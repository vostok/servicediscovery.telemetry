using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Vostok.ServiceDiscovery.Telemetry.Event;
using Vostok.ServiceDiscovery.Telemetry.EventDescription;
using Vostok.ServiceDiscovery.Telemetry.Extensions;

namespace Vostok.ServiceDiscovery.Telemetry.Tests
{
    [TestFixture]
    internal class ServiceDiscoveryEventsBuilder_Tests
    {
        private const string Environment = "default";
        private const string Application = "vostok";
        private const string Replica = "https://github.com/vostok";

        [Test]
        public void Should_correctly_build_from_event_description()
        {
            var description = SetupDescription(new ServiceDiscoveryEventDescription())
                .AddReplicas(Replica)
                .SetUserId("user")
                .SetDescription("description")
                .SetDependencies("dependencies");
            var expected = new ServiceDiscoveryEvent(ServiceDiscoveryEventKind.ReplicaStart,
                Application,
                Replica,
                Environment,
                DateTimeOffset.UtcNow,
                new Dictionary<string, string>
                    {{ServiceDiscoveryEventKeys.CreatorId, "user"}, {ServiceDiscoveryEventKeys.Description, "description"}, {ServiceDiscoveryEventKeys.Dependencies, "dependencies"}});

            var events = ServiceDiscoveryEventsBuilder.FromDescription(description);
            var serviceDiscoveryEvent = events.Single();

            serviceDiscoveryEvent.Should().BeEquivalentTo(expected, options => options.Excluding(sdEvent => sdEvent.Timestamp));
        }

        [Test]
        public void Should_build_one_event_for_each_replica()
        {
            var replicas = Enumerable.Range(0, 10).Select(i => $"{Replica}:{i}").ToArray();
            var expected = replicas.Select(replica =>
                new ServiceDiscoveryEvent(ServiceDiscoveryEventKind.ReplicaStart, Application, replica, Environment, DateTimeOffset.UtcNow, new Dictionary<string, string>()));

            var description = SetupDescription(new ServiceDiscoveryEventDescription())
                .AddReplicas(replicas);

            var events = ServiceDiscoveryEventsBuilder.FromDescription(description);

            events.Should().BeEquivalentTo(expected, options => options.Excluding(sdEvent => sdEvent.Timestamp));
        }

        [Test]
        public void Should_return_empty_for_null_application()
        {
            var replicas = Enumerable.Range(0, 10).Select(i => $"{Replica}:{i}").ToArray();

            var description = new ServiceDiscoveryEventDescription()
                .AddReplicas(replicas);

            var events = ServiceDiscoveryEventsBuilder.FromDescription(description);

            events.Should().BeEmpty();
        }

        private static IServiceDiscoveryEventDescription SetupDescription(IServiceDiscoveryEventDescription description)
        {
            return description.SetApplication(Application)
                .SetEnvironment(Environment)
                .SetEventKind(ServiceDiscoveryEventKind.ReplicaStart);
        }
    }
}