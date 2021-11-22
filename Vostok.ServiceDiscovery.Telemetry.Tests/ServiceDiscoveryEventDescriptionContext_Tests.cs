using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable PossibleNullReferenceException

namespace Vostok.ServiceDiscovery.Telemetry.Tests
{
    [TestFixture]
    internal class ServiceDiscoveryEventDescriptionContext_Tests
    {
        [Test]
        public void Should_create_new_description_on_every_call()
        {
            using (ServiceDiscoveryEventDescriptionContext.Create().AddReplicas("replica1"))
            {
                ServiceDiscoveryEventDescriptionContext.CurrentDescription.Replicas.Should().ContainSingle(s => s == "replica1");
                using (ServiceDiscoveryEventDescriptionContext.Create().AddReplicas("replica2"))
                {
                    ServiceDiscoveryEventDescriptionContext.CurrentDescription.Replicas.Should().ContainSingle(s => s == "replica2");
                    using (ServiceDiscoveryEventDescriptionContext.Create().AddReplicas("replica3"))
                        ServiceDiscoveryEventDescriptionContext.CurrentDescription.Replicas.Should().ContainSingle(s => s == "replica3");
                }
            }
        }

        [Test]
        public void Should_continue_correctly_with_nested_description()
        {
            var nestedProperties = new Dictionary<string, string> {{"key", "value"}, {"key1", "value1"}, {"key2", "value2"}, {"key3", "value3"}};

            using (ServiceDiscoveryEventDescriptionContext.Create().AddProperty("key", "value"))
            {
                var initialProperty = ServiceDiscoveryEventDescriptionContext.CurrentDescription.Properties;

                using (ServiceDiscoveryEventDescriptionContext.Continue().AddProperty("key1", "value1"))
                using (ServiceDiscoveryEventDescriptionContext.Continue().AddProperty("key2", "value2"))
                using (ServiceDiscoveryEventDescriptionContext.Continue().AddProperty("key3", "value3"))
                    ServiceDiscoveryEventDescriptionContext.CurrentDescription.Properties.Should().BeEquivalentTo(nestedProperties);

                ServiceDiscoveryEventDescriptionContext.CurrentDescription.Properties.Should().BeEquivalentTo(initialProperty);
            }

            ServiceDiscoveryEventDescriptionContext.CurrentDescription.Should().BeNull();
        }

        [Test]
        public void Should_continue_with_new_description_if_current_null()
        {
            ServiceDiscoveryEventDescriptionContext.CurrentDescription = null;
            var expectedProperties = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}};

            using (ServiceDiscoveryEventDescriptionContext.Continue().AddProperty("key1", "value1").AddProperty("key2", "value2"))
                ServiceDiscoveryEventDescriptionContext.CurrentDescription.Properties.Should().BeEquivalentTo(expectedProperties);

            ServiceDiscoveryEventDescriptionContext.CurrentDescription.Should().BeNull();
        }
    }
}