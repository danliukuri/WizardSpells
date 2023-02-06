using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Services.Transformation;
using WizardSpells.Tests.Utilities.Features.Services.Transformation;
using Create = WizardSpells.Tests.Utilities.Features.Services.Transformation.Create;

namespace WizardSpells.Tests.EditMode.Features.Services.Transformation
{
    public class PositionChangerTests
    {
        private CharacterController _characterController;
        
        [OneTimeSetUp]
        public void CreateGameObjects()
        {
            Utilities.Common.Create.Ground();
            _characterController = Create.CharacterController();
        }

        [SetUp]
        public void ResetGameObjects() => _characterController.transform.position = default;

        [Test]
        public void WhenChangePosition_AndObjectIsGrounded_AndMotionForceIsDown_ThenObjectShouldBeGrounded()
        {
            // Arrange
            _characterController.MakeGrounded();
            IGroundableObjectData groundableObjectData =
                Substitute.GroundableObjectData(_characterController.isGrounded);
            PositionChanger positionChanger = Create.PositionChanger(_characterController, groundableObjectData);

            // Act
            positionChanger.ChangePosition(Vector3.down);

            // Assert
            groundableObjectData.IsGrounded.Should().BeTrue();
        }

        [Test]
        public void WhenChangePosition_AndObjectIsGrounded_AndMotionForceIsUp_ThenObjectShouldNotBeGrounded()
        {
            // Arrange
            _characterController.MakeGrounded();
            IGroundableObjectData groundableObjectData =
                Substitute.GroundableObjectData(_characterController.isGrounded);
            PositionChanger positionChanger = Create.PositionChanger(_characterController, groundableObjectData);

            // Act
            positionChanger.ChangePosition(Vector3.up);

            // Assert
            groundableObjectData.IsGrounded.Should().BeFalse();
        }

        [Test]
        public void WhenChangePosition_AndObjectIsNotGrounded_AndMotionForceIsDown_ThenObjectShouldNotBeGrounded()
        {
            // Arrange
            _characterController.MakeUngrounded();
            IGroundableObjectData groundableObjectData =
                Substitute.GroundableObjectData(_characterController.isGrounded);
            PositionChanger positionChanger = Create.PositionChanger(_characterController, groundableObjectData);

            // Act
            positionChanger.ChangePosition(Vector3.down);

            // Assert
            groundableObjectData.IsGrounded.Should().BeFalse();
        }

        [Test]
        public void WhenChangePosition_AndObjectIsNotGrounded_AndMotionForceIsUp_ThenObjectShouldNotBeGrounded()
        {
            // Arrange
            _characterController.MakeUngrounded();
            IGroundableObjectData groundableObjectData = 
                Substitute.GroundableObjectData(_characterController.isGrounded);
            PositionChanger positionChanger = Create.PositionChanger(_characterController, groundableObjectData);

            // Act
            positionChanger.ChangePosition(Vector3.up);

            // Assert
            groundableObjectData.IsGrounded.Should().BeFalse();
        }
    }
}