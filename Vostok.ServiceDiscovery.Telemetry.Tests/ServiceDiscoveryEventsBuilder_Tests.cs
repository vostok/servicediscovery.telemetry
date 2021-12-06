using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Vostok.ServiceDiscovery.Telemetry.Event;
using Vostok.ServiceDiscovery.Telemetry.EventsBuilder;

namespace Vostok.ServiceDiscovery.Telemetry.Tests
{
    [TestFixture]
    internal class ServiceDiscoveryEventsBuilder_Tests
    {
        private const string Environment = "default";
        private const string Application = "vostok";
        private const string Replica = "https://github.com/vostok";
        private readonly DateTimeOffset timestamp = DateTimeOffset.Now;
        private ServiceDiscoveryEventsBuilder eventsBuilder;

        [SetUp]
        public void SetUp() =>
            eventsBuilder = new ServiceDiscoveryEventsBuilder();

        [Test]
        public void Should_correctly_build_event()
        {
            SetupBuilder(eventsBuilder).AddReplicas(Replica).SetUserId("user").SetDescription("description").SetDependencies("dependencies").SetTimestamp(timestamp);
            var expected = new ServiceDiscoveryEvent(ServiceDiscoveryEventKind.ReplicaStarted,
                Environment,
                Application,
                Replica,
                timestamp,
                new Dictionary<string, string>
                {
                    {ServiceDiscoveryEventWellKnownProperties.UserId, "user"},
                    {ServiceDiscoveryEventWellKnownProperties.Description, "description"},
                    {ServiceDiscoveryEventWellKnownProperties.Dependencies, "dependencies"}
                });

            eventsBuilder.BuildEvents().Single().Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Should_build_one_event_for_each_replica()
        {
            var replicas = Enumerable.Range(0, 10).Select(i => $"{Replica}:{i}").ToArray();
            var expected = replicas.Select(replica =>
                new ServiceDiscoveryEvent(ServiceDiscoveryEventKind.ReplicaStarted, Environment, Application, replica, timestamp, new Dictionary<string, string>()));

            SetupBuilder(eventsBuilder).SetTimestamp(timestamp).AddReplicas(replicas);

            eventsBuilder.BuildEvents().Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Should_not_build_events_with_non_configured_builder()
        {
            eventsBuilder.BuildEvents().Should().BeEmpty();
        }

        private static IServiceDiscoveryEventsBuilder SetupBuilder(IServiceDiscoveryEventsBuilder description)
        {
            return description.SetApplication(Application)
                .SetEnvironment(Environment)
                .SetKind(ServiceDiscoveryEventKind.ReplicaStarted);
        }
    }
}