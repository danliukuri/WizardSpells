using FluentAssertions;
using FluentAssertions.Events;
using NUnit.Framework;
using UnityEngine;
using WizardSpells.Features.Services.Force.MotionForce;
using WizardSpells.Tests.EditMode.TestUtilities;

namespace WizardSpells.Tests.EditMode.Features.Services.Force.MotionForce
{
    public class MotionForceAccumulatorTests
    {
        [Test]
        public void WhenAccumulatePermanentForce_AndForceIsVectorOne_ThenShouldRaiseMotionForceChangedEvent()
        {
            // Arrange
            MotionForceAccumulator motionForceAccumulator = Create.MotionForceAccumulator();
            using IMonitor<IMotionForceProvider> monitor = motionForceAccumulator.Monitor<IMotionForceProvider>();

            // Act
            motionForceAccumulator.AccumulatePermanentForce(Vector3.one);

            // Assert
            monitor.Should().Raise(nameof(motionForceAccumulator.MotionForceChanged));
        }

        [Test]
        public void WhenAccumulatePermanentForce_AndForceIsOneByY_ThenShouldRaiseMotionForceChangedEvent()
        {
            // Arrange
            MotionForceAccumulator motionForceAccumulator = Create.MotionForceAccumulator();
            using IMonitor<IMotionForceProvider> monitor = motionForceAccumulator.Monitor<IMotionForceProvider>();

            // Act
            motionForceAccumulator.AccumulatePermanentForce(y: Vector3.one.y);

            // Assert
            monitor.Should().Raise(nameof(motionForceAccumulator.MotionForceChanged));
        }

        [Test]
        public void WhenAccumulateInstantForce_AndForceIsVectorOne_ThenShouldRaiseMotionForceChangedEvent()
        {
            // Arrange
            MotionForceAccumulator motionForceAccumulator = Create.MotionForceAccumulator();
            using IMonitor<IMotionForceProvider> monitor = motionForceAccumulator.Monitor<IMotionForceProvider>();

            // Act
            motionForceAccumulator.AccumulateInstantForce(Vector3.one);

            // Assert
            monitor.Should().Raise(nameof(motionForceAccumulator.MotionForceChanged));
        }
    }
}