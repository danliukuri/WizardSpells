using FluentAssertions;
using FluentAssertions.Events;
using NUnit.Framework;
using UnityEngine;
using WizardSpells.Features.Services.Force.Accumulators;
using WizardSpells.Features.Services.Force.Providers;
using WizardSpells.Tests.Utilities.Features.Services.Force.Accumulators;

namespace WizardSpells.Tests.EditMode.Features.Services.Force.Accumulators
{
    public class ForceAccumulatorTests
    {
        [Test]
        public void WhenAccumulatePermanentForce_AndForceIsVectorOne_ThenShouldRaiseMotionForceChangedEvent()
        {
            // Arrange
            ForceAccumulator forceAccumulator = Create.ForceAccumulator();
            using IMonitor<IForceProvider> monitor = forceAccumulator.Monitor<IForceProvider>();

            // Act
            forceAccumulator.AccumulatePermanentForce(Vector3.one);

            // Assert
            monitor.Should().Raise(nameof(forceAccumulator.ForceChanged));
        }

        [Test]
        public void WhenAccumulatePermanentForce_AndForceIsOneByY_ThenShouldRaiseMotionForceChangedEvent()
        {
            // Arrange
            ForceAccumulator forceAccumulator = Create.ForceAccumulator();
            using IMonitor<IForceProvider> monitor = forceAccumulator.Monitor<IForceProvider>();

            // Act
            forceAccumulator.AccumulatePermanentForce(y: Vector3.one.y);

            // Assert
            monitor.Should().Raise(nameof(forceAccumulator.ForceChanged));
        }

        [Test]
        public void WhenAccumulateInstantForce_AndForceIsVectorOne_ThenShouldRaiseMotionForceChangedEvent()
        {
            // Arrange
            ForceAccumulator forceAccumulator = Create.ForceAccumulator();
            using IMonitor<IForceProvider> monitor = forceAccumulator.Monitor<IForceProvider>();

            // Act
            forceAccumulator.AccumulateInstantForce(Vector3.one);

            // Assert
            monitor.Should().Raise(nameof(forceAccumulator.ForceChanged));
        }
    }
}