using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Vostok.Context;
using Vostok.ServiceDiscovery.Telemetry.Event;
using Vostok.ServiceDiscovery.Telemetry.EventsBuilder;
using Vostok.ServiceDiscovery.Telemetry.EventsSender;

// ReSharper disable PossibleNullReferenceException

namespace Vostok.ServiceDiscovery.Telemetry.Tests
{
    [TestFixture]
    internal class ServiceDiscoveryEventContextToken_Tests
    {
        private const string Environment = "default";
        private const string Application = "vostok";
        private const string Replica = "https://github.com/vostok";
        private readonly IServiceDiscoveryEventsContext eventContext = new ServiceDiscoveryEventsContext(
            new ServiceDiscoveryEventsContextConfig(new DevNullServiceDiscoveryEventsSender()));

        [Test]
        public void Should_replace_new_builder_with_old_after_dispose()
        {
            FlowingContext.Globals.Get<ServiceDiscoveryEventsBuilder>().Should().BeNull();

            using (new ServiceDiscoveryEventsContextToken(builder => {}))
            {
                var first = FlowingContext.Globals.Get<ServiceDiscoveryEventsBuilder>();
                using (new ServiceDiscoveryEventsContextToken(builder => {}))
                {
                    var second = FlowingContext.Globals.Get<ServiceDiscoveryEventsBuilder>();

                    first.Should().NotBeNull();
                    second.Should().NotBeNull();
                }

                FlowingContext.Globals.Get<ServiceDiscoveryEventsBuilder>().Should().Be(first);
            }

            FlowingContext.Globals.Get<ServiceDiscoveryEventsBuilder>().Should().BeNull();
        }

        [Test]
        public void Should_continue_correctly_with_nested_tokens()
        {
            var nestedProperties = new Dictionary<string, string> {{"key", "value"}, {"key1", "value1"}, {"key2", "value2"}, {"key3", "value3"}};

            using (new ServiceDiscoveryEventsContextToken(builder => SetupBuilder(builder).SetProperty("key", "value")))
            {
                var initialProperty = eventContext.CurrentEvents.Single().Properties;
                using (new ServiceDiscoveryEventsContextToken(builder => builder.SetProperty("key1", "value1")))
                using (new ServiceDiscoveryEventsContextToken(builder => builder.SetProperty("key2", "value2")))
                using (new ServiceDiscoveryEventsContextToken(builder => builder.SetProperty("key3", "value3")))
                    eventContext.CurrentEvents.Single().Properties.Should().BeEquivalentTo(nestedProperties);

                eventContext.CurrentEvents.Single().Properties.Should().BeEquivalentTo(initialProperty);
            }
        }

        [Test]
        public void Should_create_new_builder_if_current_null()
        {
            var expectedProperties = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}};

            FlowingContext.Globals.Get<ServiceDiscoveryEventsBuilder>().Should().BeNull();

            using (new ServiceDiscoveryEventsContextToken(builder => SetupBuilder(builder).SetProperty("key1", "value1").SetProperty("key2", "value2")))
                eventContext.CurrentEvents.Single().Properties.Should().BeEquivalentTo(expectedProperties);
        }

        private static IServiceDiscoveryEventsBuilder SetupBuilder(IServiceDiscoveryEventsBuilder description)
        {
            return description.SetApplication(Application)
                .SetEnvironment(Environment)
                .AddReplicas(Replica)
                .SetKind(ServiceDiscoveryEventKind.ReplicaStarted);
        }
    }
}